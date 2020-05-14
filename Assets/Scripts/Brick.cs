using UnityEngine;

public class Brick : MonoBehaviour {
	void OnCollisionEnter(Collision collision) {
		// destroy this brick
		Destroy(gameObject);
	}
}
