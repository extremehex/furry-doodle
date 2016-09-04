using UnityEngine;

public class EnemyShipController : MonoBehaviour
{

    public float speed;
    public GameObject explosion;

    public int scoreValue;

    public GameObject shot;
    public Transform[] shotSpawns;
    public float fireRate;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.velocity = transform.up * speed;

        InvokeRepeating("Fire", fireRate, fireRate);
    }

    void Update()
    {
        if (transform.position.y < ScreenData.min.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "PlayerBullet")
        {
            GameController.AddScore(scoreValue);
            GameObject exp = (GameObject)Instantiate(explosion, transform.position, transform.rotation);
            Destroy(exp, 2.0f);
            Destroy(gameObject);
        }
        if (other.tag == "PlayerBullet")
        {
            Destroy(other.gameObject);
        }
    }

    void Fire ()
    {
        foreach (Transform point in shotSpawns)
        {
            Instantiate(shot, point.position, Quaternion.identity);
        }
    }

}