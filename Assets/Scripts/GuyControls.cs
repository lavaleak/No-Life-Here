using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//TODO: Se pá colocar o texto aqui não seja a melhor solução

[RequireComponent (typeof(Animator))]

public class GuyControls : MonoBehaviour {

	public float speed;
	public float rotationSpeed;
	public float cameraSpeed;
	private Animator animator;
	static public int zombies = 0;
	public Text zombieCount;

	void Start () {
		animator = GetComponent<Animator>();
	}

	void rotate() {
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

		if (Input.GetAxis ("Horizontal") > 0)
			animator.SetBool ("TurnRight", true);

		else
			animator.SetBool ("TurnRight", false);

		if (Input.GetAxis ("Horizontal") < 0)
			animator.SetBool ("TurnLeft", true);

		else
			animator.SetBool ("TurnLeft", false);

		rotation *= Time.deltaTime;
		transform.Rotate(0, rotation, 0);
	}

	void walk() {
		float translation = Input.GetAxis("Vertical") * speed;

		if (Input.GetAxis ("Vertical") != 0) {
			animator.SetBool ("TurnRight", false);
			animator.SetBool ("TurnLeft", false);
		}

		animator.SetFloat ("Walk", Input.GetAxis ("Vertical"));

		translation *= Time.deltaTime;

		transform.Translate(0, 0, translation);
	}

	void cameraFollowing() {
		Vector3 pos = this.transform.position;
		Vector3 camPos = Camera.main.transform.position;
		float x = 0;
		float y = 0;

		if (camPos.x != pos.x)
			x = (pos.x - camPos.x) * cameraSpeed;

		if (camPos.z != pos.z)
			y = (pos.z - camPos.z) * cameraSpeed;

		x *= Time.deltaTime;
		y *= Time.deltaTime;

		Camera.main.transform.Translate(x, y, 0);
	}

	void Update () {
		cameraFollowing ();
		walk ();
		rotate ();
		zombieCount.text = zombies.ToString();

		if (zombies >= 18)
			SceneManager.LoadScene ("GameEnd");
	}
}
