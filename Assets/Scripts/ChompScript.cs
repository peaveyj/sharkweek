using UnityEngine;
using System.Collections;

public class ChompScript : MonoBehaviour {

	private Animator animator;
	private PlayerHealth playerHealth;

	void Awake() {
		// Get the animator
		animator = GetComponent<Animator>();
		playerHealth = GameObject.Find ("player").GetComponent<PlayerHealth> ();
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		if (!playerHealth.IsDead) {
			animator.SetTrigger ("Chomp");
		}
	}
}
