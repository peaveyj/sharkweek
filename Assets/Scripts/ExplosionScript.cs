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

	void OnEnable()
	{
		StartCoroutine(Shrink());
	}
	
	IEnumerator Shrink()
	{
		timeLeft = explosionTime;
		while (timeLeft > 0) {
			timeLeft -= Time.deltaTime;
			yield return 0;
		}
		this.Recycle();
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		string otherName = otherCollider.gameObject.name;
		switch (otherName) {
		case "shark_body":
			playerHealth.Hit(1);
			break;
		}
	}
}
