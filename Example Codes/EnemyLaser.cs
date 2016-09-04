using UnityEngine;

public class EnemyLaser : MonoBehaviour {

    public float speed;

	void Start () {
        GetComponent<Rigidbody>().velocity = -transform.up * speed;
    }
	
	void Update () {
        if (transform.position.y < ScreenData.min.y)
        {
            Destroy(gameObject);
        }
    }
}
