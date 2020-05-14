using DG.Tweening;
using UnityEngine;
public class CameraEffects : MonoBehaviour {

	void Start() {
		transform.DOMoveY(1, 1).SetEase(Ease.OutBounce);
	}

}
