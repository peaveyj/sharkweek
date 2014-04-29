using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float timeToExplode = 2.0f;

	private PlayerHealth playerHealth;

	public ExplosionScript explosionScriptPrefab;

	void OnEnable() {
		StartCoroutine(Fall());
	}
	
	void OnDisable() {
		StopAllCoroutines();
	}

	// Use this for initialization
	void Start () {
		playerHealth = GameObject.Find ("player").GetComponent<PlayerHealth> ();
		explosionScriptPrefab.CreatePool ();
	}
	
	// Update is called once per frame
	IEnumerator Fall () {
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
		bool isVisible = true;
		float explodeTimer = 0f;
		while (isVisible && explodeTimer < timeToExplode) {
			isVisible = GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
			explodeTimer += Time.deltaTime;
			yield return 0;
		}
		if (explodeTimer >= timeToExplode) {
			explosionScriptPrefab.Spawn(transform.position);
		}
		this.Recycle ();
	}
	

}
