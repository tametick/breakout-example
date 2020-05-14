using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paddle : MonoBehaviour {
	public Joint joint;
	public Rigidbody puck;

	public List<Rigidbody> extraPucks;

	void Update() {
		// move paddle right
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.Translate(new Vector3(10 * Time.deltaTime, 0, 0));
		}

		// move paddle left
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.Translate(new Vector3(-10 * Time.deltaTime, 0, 0));
		}

		// launch puck
		if (Input.GetKeyDown(KeyCode.Space) && joint != null) {
			joint.breakForce = 0;
			puck.AddForce(new Vector3(0, 10, 0));
			puck.GetComponent<Puck>().launched = true;
		}
	}

	void Start() {
		NewPuck();
	}

	public void NewPuck() {
		if (extraPucks.Count == 0) {
			// game over
			SceneManager.LoadScene("Main");
		} else {
			// fetch a new puck
			puck = extraPucks[0];
			extraPucks.RemoveAt(0);

			// attach the new puck to my paddle, right on top of it
			puck.transform.position = transform.position + Vector3.up * 0.5f;
			joint = gameObject.AddComponent<FixedJoint>();
			joint.connectedBody = puck;
		}
	}

	void OnCollisionEnter(Collision collision) {
		float xDiff = puck.transform.position.x - transform.position.x;

		Vector3 direction = new Vector3(xDiff * 10, 10, 0);
		puck.AddForce(direction, ForceMode.VelocityChange);
	}
}
