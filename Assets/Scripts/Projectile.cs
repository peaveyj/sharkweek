using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float timeToExplode = 2.0f;

	private PlayerHealth playerHealth;
	private float explodeTimer = 2.0f;

	public ExplosionScript explosionScriptPrefab;

	// Use this for initialization
	void Start () {
		playerHealth = GameObject.Find ("player").GetComponent<PlayerHealth> ();
		explosionScriptPrefab.CreatePool ();
		explodeTimer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
		bool isVisible = GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
		if (!isVisible) {
			this.Recycle();
		}

		explodeTimer += Time.deltaTime;
		if (explodeTimer >= timeToExplode) {
			explosionScriptPrefab.Spawn(transform.position);
			this.Recycle();
		}
	}
	

}
