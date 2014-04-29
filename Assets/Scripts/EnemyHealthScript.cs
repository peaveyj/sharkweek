using UnityEngine;
using System.Collections;

public class EnemyHealthScript : MonoBehaviour {

	public int health = 1;
	public int worthScore = 100;

	private bool isInMouth = false;

	private ScoreScript score;
	private PlayerHealth playerHealth;
	private Sounds sounds;

	// Use this for initialization
	void Start () {
		score = GameObject.Find("Scripts").GetComponent<ScoreScript>();
		playerHealth = GameObject.Find ("player").GetComponent<PlayerHealth> ();
		sounds = GameObject.FindObjectOfType<Sounds> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		if (otherCollider.gameObject.name == "shark_head") {
			isInMouth = true;
		}
		else if (otherCollider.gameObject.name == "shark_mouth" && isInMouth && !playerHealth.IsDead) {
			sounds.Play("omnom" + Random.Range(1,2));

			string soundToPlay = null;
			if (gameObject.name.StartsWith("inner_tuber")) {
				soundToPlay = "fscream1";
			} else if (gameObject.name.StartsWith("surfer_dude")) {
				soundToPlay = "scared1";
			}

			if (null != soundToPlay) {
				sounds.Play(soundToPlay);
			}

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
