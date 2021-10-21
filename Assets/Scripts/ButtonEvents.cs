using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour {
	public void continueGame() {
		MenuPauseGameOver.pause = false;
	}

	public void quit() {
		Application.Quit();
	}

	public void tryAgain() {
		MenuPauseGameOver.gameOver = false;
		GuyControls.zombies = 0;
		SceneManager.LoadScene ("MainScene");
	}
}
