using DG.Tweening;
using UnityEngine;

public class Puck : MonoBehaviour {
	public Rigidbody rb;
	public bool launched;

	const float minSpeed = 8f;
	const float maxSpeed = 12f;

	ParticleSystem particles;
	Renderer rend;

	private void Start() {
		particles = GetComponentInChildren<ParticleSystem>();
		rend = GetComponentsInChildren<Renderer>()[1];
	}

	Tweener punchTween;
	private void OnCollisionEnter(Collision collision) {
		particles.Play();
		if (punchTween == null) {
			punchTween.Kill();
			rend.transform.localScale = Vector3.one;
		}
		punchTween = rend.transform.DOPunchScale(Vector3.one / 2, .25f);
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
