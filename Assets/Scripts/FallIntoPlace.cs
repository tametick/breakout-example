using DG.Tweening;
using UnityEngine;

public class FallIntoPlace : MonoBehaviour {
	void Start() {
		float targetY = transform.position.y;
		transform.Translate(new Vector3(0, 10, 0));
		transform.DOMoveY(targetY, Random.Range(0.5f, 1)).SetEase(Ease.OutBounce);
	}

}
