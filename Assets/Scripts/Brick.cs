using UnityEngine;

public class Brick : MonoBehaviour {
	void OnCollisionEnter(Collision collision) {
		GetComponent<AudioSource>().Play();

		// remove this brick
		enabled = false;
		GetComponent<Renderer>().enabled = false;
		GetComponent<Collider>().enabled = false;
	}
}
