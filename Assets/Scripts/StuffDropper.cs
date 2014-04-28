using UnityEngine;
using System.Collections;

public class StuffDropper : MonoBehaviour {

	public Projectile projectilePrefab;
	public Vector2 projectileSpawnTime = new Vector2 (3.0f, 8.0f);
	public Vector2 projectileSpawnOffset = Vector2.zero;

	private float projectileSpawnCountdown = 5.0f;

	// Use this for initialization
	void Start () {
		if (null != projectilePrefab) {
			projectilePrefab.CreatePool ();
			projectileSpawnCountdown = Random.Range(projectileSpawnTime.x, projectileSpawnTime.y);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (null != projectilePrefab) {
			projectileSpawnCountdown -= Time.deltaTime;
			if (projectileSpawnCountdown <= 0) {
				projectilePrefab.Spawn(transform.position + Vector3.down*projectileSpawnOffset.y + Vector3.right*projectileSpawnOffset.x);
				projectileSpawnCountdown = Random.Range(projectileSpawnTime.x, projectileSpawnTime.y);
			}
		}
	}
}
