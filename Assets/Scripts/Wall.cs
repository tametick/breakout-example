﻿using UnityEngine;

public class Wall : MonoBehaviour {
	private void OnCollisionEnter(Collision collision) {
		GetComponent<AudioSource>().Play();
	}
}
