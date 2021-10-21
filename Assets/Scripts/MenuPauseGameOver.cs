using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuPauseGameOver : MonoBehaviour {

	static public bool pause = false;
	static public bool gameOver = false;

	public GameObject Pause;
	public GameObject GameOver;

	void Update () {
		if (Input.GetButton ("Cancel"))
			pause = true;

		if (pause) {
			Time.timeScale = 0;
			Pause.SetActive (true);
		}

		else if (gameOver) {
			Time.timeScale = 0;
			GameOver.SetActive (true);
		}

		else {
			Time.timeScale = 1.0f;
			Pause.SetActive (false);
			GameOver.SetActive (false);
		}
	}
}
