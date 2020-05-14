using UnityEngine;

public class Puck : MonoBehaviour {
	public Rigidbody rb;
	public bool launched;

	void FixedUpdate() {
		if (launched) {
			float speed = rb.velocity.magnitude;

			// keep a launched puck in speeds between 7.5 and 15
			if (speed < 7.5f) {
				// too slow, make it faster
				rb.velocity *= 2;
			} else if (speed > 15) {
				// too fast, make it slower
				rb.velocity /= 2;
			}
		}
	}
}
