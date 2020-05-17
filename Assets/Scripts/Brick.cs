using UnityEngine;

public class Brick : MonoBehaviour {
	public CameraEffect cameraEffect;

	void OnCollisionEnter(Collision collision) {
		GetComponent<AudioSource>().Play();
		cameraEffect.Shake();

		// remove this brick
		enabled = false;
		GetComponent<Renderer>().enabled = false;
		GetComponent<Collider>().enabled = false;
	}
}
