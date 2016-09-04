using UnityEngine;

public class AstreoidController : MonoBehaviour {

    public float speed;
    public float rotate;
    public GameObject explosion;

    public int scoreValue;

    void Start () {
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.velocity = transform.up * speed;
        rb.angularVelocity = Random.insideUnitSphere * rotate;
    }
	
	void Update () {
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

}