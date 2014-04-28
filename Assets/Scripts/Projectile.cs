using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	private PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		playerHealth = GameObject.Find ("player").GetComponent<PlayerHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
		bool isVisible = GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
		if (!isVisible) {
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
