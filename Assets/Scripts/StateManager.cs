using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour {
	public static StateManager Instance;

	void Start() {
		Instance = this;
	}

	public void RestartGame() {
		SceneManager.LoadScene("Main");
	}
}
