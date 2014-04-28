using UnityEngine;
using System.Collections;

public class EnemyHealthScript : MonoBehaviour {

	public int health = 1;
	public int worthScore = 100;

	private bool isInMouth = false;

	private ScoreScript score;
	private PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		score = GameObject.Find("ScoreText").GetComponent<ScoreScript>();
		playerHealth = GameObject.Find ("player").GetComponent<PlayerHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		if (otherCollider.gameObject.name == "shark_head") {
			isInMouth = true;
		}
		else if (otherCollider.gameObject.name == "shark_mouth" && isInMouth && !playerHealth.IsDead) {
			health--;
			if (health <= 0) {
				this.Recycle();
				score.addScore(worthScore);
			}
		}
		else if (otherCollider.gameObject.name == "leftEdge") {
			this.Recycle();
		}
	}
}
