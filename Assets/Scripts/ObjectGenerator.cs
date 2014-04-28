using UnityEngine;
using System.Collections;

public class ObjectGenerator : MonoBehaviour {

	public EnemyHealthScript enemyPrefab;
	public float spawnDinnerTime = 3.0f;
	private float spawnDinnerCountdown = 0.0f;
	private const float SPAWN_X = 10f;
	private const float SPAWN_Y_RANGE = 5.5f;   //set to 0 to turn off randomness
	private const float SPAWN_Y_OFFSET = -4.0f;   //-4 from random min point (0) is bottom of sea, 2 is on the surface

	public Transform spawner;

	public EnemyHealthScript enemyInstance;
	// Use this for initialization
	void Start () {
		enemyPrefab.CreatePool();

	
	}
	
	// Update is called once per frame
	void Update () {
		spawnDinnerCountdown -= Time.deltaTime;
		if (spawnDinnerCountdown <= 0)
		{
			spawnDinnerCountdown = spawnDinnerTime;
			//enemyInstance = ObjectPool.Spawn(fish_dinner, new Vector3(10, Random.Range(-3f,1.3f),0));
			spawner.position = new Vector3(SPAWN_X, Random.value*SPAWN_Y_RANGE + SPAWN_Y_OFFSET, 0);
			enemyInstance = enemyPrefab.Spawn(spawner.position,spawner.rotation);
		}
	
	}
}
