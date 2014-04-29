using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 1;
	public float timeDeathToTransition = 2.0f;

	private int health = 1;
	private Animator sharkEyeAnimator;
	private Animator sharkTailAnimator;
	private float afterDeathCounter = 0f;
	private Sounds sounds;

	// Use this for initialization
	void Start () {
		health = startingHealth;
		sharkEyeAnimator = GameObject.Find ("shark_eye").GetComponent<Animator> ();
		sharkTailAnimator = GameObject.Find ("shark_body").GetComponent<Animator> ();
		sounds = GameObject.FindObjectOfType<Sounds> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (IsDead) {
			afterDeathCounter += Time.deltaTime;
			if (afterDeathCounter > timeDeathToTransition) {
				Application.LoadLevel("ScoreScreen");
			}
		}
	}

	public bool IsDead { get { return health <= 0; } }

	private void Die() {
		sharkEyeAnimator.SetTrigger ("Die");
		sharkTailAnimator.SetTrigger ("Die");
		afterDeathCounter = 0f;
	}

	public int Hit(int damage) {
		sounds.Play ("ow1");
		health -= damage;
		if (IsDead) {
			Die();
		}
		return health;
	}
}
