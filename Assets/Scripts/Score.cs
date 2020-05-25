using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public static Score Instance;

	Text label;
	int score;
	void Start() {
		Instance = this;
		label = GetComponent<Text>();
		UpdateLabel();
	}

	void UpdateLabel() {
		label.text = $" <color=white>Score: {score}</color>";
	}

	public void AddToScore(int toAdd) {
		score += toAdd;
		UpdateLabel();
	}
}
