using UnityEngine;

public class Puck : MonoBehaviour {
	public Rigidbody rb;
	public bool launched;
	const float minSpeed = 8f;
	const float maxSpeed = 12f;

	void FixedUpdate() {
		if (launched) {
			float speed = rb.velocity.magnitude;

			// keep a launched puck in speeds between minSpeed and maxSpeed
			if (speed < minSpeed) {
				// too slow, make it faster
				rb.velocity *= 10f / minSpeed;
			} else if (speed > maxSpeed) {
				// too fast, make it slower
				rb.velocity *= 10f / maxSpeed;
			}
		}
	}
}
