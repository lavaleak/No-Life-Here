using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

	private Scene scene;
	private bool sair = false;

	public void goToMenu() {
		SceneManager.LoadScene ("MainMenu");
	}

	void setSair() {
		sair = true;
	}

	void Start() {
		scene = SceneManager.GetActiveScene();
		Invoke ("setSair", 5);
	}

	void Update () {
		if (Input.anyKey || Input.GetButton ("Submit")) {
			if (scene.name == "MainMenu")
				SceneManager.LoadScene ("Story");
			if (sair) {
				if (scene.name == "GameEnd")
					SceneManager.LoadScene ("MainMenu");
				if (scene.name == "Story")
					SceneManager.LoadScene ("MainScene");
			}
		}
	}
}
