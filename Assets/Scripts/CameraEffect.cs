using DG.Tweening;
using UnityEngine;

public class CameraEffect : MonoBehaviour {
	public void Shake() {
		transform.DOShakePosition(.25f, .25f);
	}
}
