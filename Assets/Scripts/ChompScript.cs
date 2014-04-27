using UnityEngine;
using System.Collections;

public class ChompScript : MonoBehaviour {

	private Animator animator;

	void Awake() {
		// Get the animator
		animator = GetComponent<Animator>();
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		animator.SetTrigger("Chomp");
	}
}
