using UnityEngine;

public class Puck : MonoBehaviour {
	public Rigidbody rb;
	public bool launched;

	const float minSpeed = 8f;
	const float maxSpeed = 12f;

	ParticleSystem particles;

	private void Start() {
		particles = GetComponentInChildren<ParticleSystem>();
	}

	private void OnCollisionEnter(Collision collision) {
		particles.Play();
	}

	void FixedUpdate() {
		if (launched) {
			float speed = rb.velocity.magnitude;

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
