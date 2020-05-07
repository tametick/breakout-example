using UnityEngine;

public class Brick : MonoBehaviour {
	void OnCollisionEnter(Collision collision) {
		// destroy this brick
		Destroy(gameObject);

		// bounce back puck
		Vector3 puckPosition = collision.transform.position;
		if (puckPosition.y < transform.position.y) {
			collision.rigidbody.AddForce(new Vector3(0, -10, 0), ForceMode.VelocityChange);
		} else {
			collision.rigidbody.AddForce(new Vector3(0, 10, 0), ForceMode.VelocityChange);
		}
	}
}
