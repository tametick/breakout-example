using DG.Tweening;
using UnityEngine;

public class Brick : MonoBehaviour {
	public static int bricks;
	public CameraEffect cameraEffect;
	public SpriteRenderer victory;

	private void Start() {
		bricks++;
	}

	void OnCollisionEnter(Collision collision) {
		GetComponent<AudioSource>().Play();
		cameraEffect.Shake();

		// remove this brick
		enabled = false;
		GetComponent<Renderer>().enabled = false;
		GetComponent<Collider>().enabled = false;

		bricks--;
		if (bricks == 0) {
			// win! do fancy stuff here
			victory.enabled = true;
			DOVirtual.DelayedCall(1, StateManager.Instance.RestartGame);
		}

		Score.Instance.AddToScore(1);
	}
}
