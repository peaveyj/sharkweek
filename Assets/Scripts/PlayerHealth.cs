using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 1;

	private int health = 1;
	private Animator sharkEyeAnimator;
	private Animator sharkTailAnimator;

	// Use this for initialization
	void Start () {
		health = startingHealth;
		sharkEyeAnimator = GameObject.Find ("shark_eye").GetComponent<Animator> ();
		sharkTailAnimator = GameObject.Find ("shark_body").GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool IsDead { get { return health <= 0; } }

	private void Die() {
		sharkEyeAnimator.SetTrigger ("Die");
		sharkTailAnimator.SetTrigger ("Die");
	}

	public int Hit(int damage) {
		health -= damage;
		if (IsDead) {
			Die();
		}
		return health;
	}
}
