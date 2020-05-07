using UnityEngine;

public class Floor : MonoBehaviour {
	public Paddle paddle;

	void OnCollisionEnter(Collision collision) {
		paddle.NewPuck();
	}
}
