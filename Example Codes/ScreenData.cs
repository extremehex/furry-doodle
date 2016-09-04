using UnityEngine;

public class ScreenData : MonoBehaviour {

    public static Vector2 min, max;

	void Awake () {
        Set();
	}

    public static void Set ()
    {
        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

}