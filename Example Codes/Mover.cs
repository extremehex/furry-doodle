using UnityEngine;

public class Mover : MonoBehaviour {

    //public float speed;
    public Vector2 velocity;
    private Vector3 myspeed;
    
	void Start () {
        GetComponent<Rigidbody>().velocity = new Vector3(velocity.x, velocity.y, 0);

        //GetComponent<Rigidbody>().velocity = transform.up * speed;
	}

}