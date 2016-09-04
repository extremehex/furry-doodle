using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    private AudioSource fire;

    public float speed;
    public float tilt;
    public Vector2 size2D;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    public GameObject explosion;

    private float nextFire;
    private Vector2 min, max;


    void Awake ()
    {
        rb = GetComponent<Rigidbody>();
        fire = GetComponent<AudioSource>();
    }

    void Start ()
    {
        min = ScreenData.min + size2D / 2;
        max = ScreenData.max - size2D / 2;
    }

    void Update ()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, Quaternion.identity);
            fire.Play();
        }
    }

    void FixedUpdate () {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, y, 0.0f);
        rb.velocity = movement * speed;

        rb.position = new Vector3( Mathf.Clamp(rb.position.x, min.x, max.x), Mathf.Clamp(rb.position.y, min.y, max.y), 0.0f );

        rb.rotation = Quaternion.Euler(270.0f, rb.velocity.x * -tilt, 0.0f);
	}

    void OnTriggerEnter (Collider other)
    {
        if( other.tag == "Enemy" ||other.tag == "EnemyBullet" )
        {
            GameObject exp = (GameObject)Instantiate(explosion, transform.position, transform.rotation);
            Destroy(exp, 2.0f);
            Destroy(gameObject);
            GameController.GameOver();
        }
    }

}