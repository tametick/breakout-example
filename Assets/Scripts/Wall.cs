using UnityEngine;

public class Wall : MonoBehaviour {
	public Vector3 bounceDirection;

	void OnCollisionEnter(Collision collision) {
		collision.rigidbody.AddForce(bounceDirection, ForceMode.VelocityChange);
	}
}
