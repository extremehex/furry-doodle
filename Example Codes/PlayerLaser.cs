using UnityEngine;

public class PlayerLaser : MonoBehaviour {

    public float speed;

	void Start () {
        GetComponent<Rigidbody>().velocity = transform.up * speed;
    }
	
	void Update () {
        if (transform.position.y > ScreenData.max.y)
        {
            Destroy(gameObject);
        }
    }
}
