using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paddle : MonoBehaviour {
	public Joint joint;
	public Rigidbody puck;
	public float leftLimit;
	public float rightLimit;

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

		// keep the paddle between the limits
		float newX = Mathf.Clamp(transform.position.x, leftLimit, rightLimit);
		if (transform.position.x != newX) {
			transform.position = new Vector3(newX, transform.position.y, transform.position.z);
		}

		// launch puck
		if (Input.GetKeyDown(KeyCode.Space) && joint != null) {
			joint.breakForce = 0;
			// this force will break the joint
			puck.AddForce(new Vector3(0, 1, 0));
		}
	}

	void OnJointBreak(float breakForce) {
		// once the joint is broken, launch puck upwards
		puck.AddForce(new Vector3(0, 10, 0));
		puck.GetComponent<Puck>().launched = true;
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

		Vector3 direction = new Vector3(xDiff * 10, 0, 0);
		puck.AddForce(direction, ForceMode.VelocityChange);
	}
}
