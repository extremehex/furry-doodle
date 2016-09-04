using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    private static GUIText scoreText;
    private static GUIText restartText;
    private static GUIText gameOverText;

    private static bool gameOver;
    private static bool restart;
    private static int score;

    private Vector3 min, max;

    void Awake ()
    {
        scoreText = GameObject.Find("/Display Text/Score Text").GetComponent<GUIText>();
        restartText = GameObject.Find("/Display Text/Restart Text").GetComponent<GUIText>();
        gameOverText = GameObject.Find("/Display Text/Game Over Text").GetComponent<GUIText>();
    }

    void Start ()
    {
        min = ScreenData.min + new Vector2(1, 1);
        max = ScreenData.max - new Vector2(1, 1);

        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds(startWait);
        while (true) {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(min.x, max.x), max.y);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
    }

    public static void AddScore (int extra)
    {
        score += extra;
        UpdateScore();
    }

    private static void UpdateScore ()
    {
        scoreText.text = "Score: " + score;
    }

    public static void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

}