using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

	public float explosionTime = 2.0f;

	private float timeLeft = 0f;
	
	private PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		timeLeft = explosionTime;
		playerHealth = GameObject.Find ("player").GetComponent<PlayerHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft <= 0) {
			this.Recycle();
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		string otherName = otherCollider.gameObject.name;
		switch (otherName) {
		case "shark_body":
			playerHealth.Hit(1);
			this.Recycle();
			break;
		}
	}
}
