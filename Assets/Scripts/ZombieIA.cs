using UnityEngine;
using System.Collections;

// TODO: Arrumar o NavMesh

public class ZombieIA : MonoBehaviour {

	public Transform player;
	private bool isChasing;
	private Animator animator;
	private NavMeshAgent navMeshAgent;
	private bool InIncinerator = false;

	void Start () {
		animator = GetComponent<Animator>();
		navMeshAgent = GetComponent<NavMeshAgent>();
		isChasing = false;
	}

	void rotate () {
	}

	void chase () {
		if (isChasing) {
			navMeshAgent.destination = player.position;
		}
		animator.SetBool ("Chase", isChasing);
		animator.SetFloat ("animationTime",Random.value);
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player")
			isChasing = true;
	}

	void OnCollisionEnter (Collision other) {
		if (other.collider.tag == "Player")
			MenuPauseGameOver.gameOver = true;

		if (other.collider.tag == "Incinerator" && InIncinerator == false) {
			GuyControls.zombies++;
			InIncinerator = true;
		}
	}

	void OnCollisionExit (Collision other) {
		if (other.collider.tag == "Incinerator" && InIncinerator == true) {
			GuyControls.zombies--;
			InIncinerator = false;
		}
	}

	void Update () {
		chase ();
	}
}
