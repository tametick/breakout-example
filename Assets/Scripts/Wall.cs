using UnityEngine;

public class Wall : MonoBehaviour {
	void OnCollisionEnter(Collision collision) {
		GetComponent<AudioSource>().Play();
	}
}
