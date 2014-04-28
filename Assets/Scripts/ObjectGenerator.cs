using UnityEngine;
using System.Collections;

public class ObjectGenerator : MonoBehaviour {

	public EnemyHealthScript angelFishPrefab;
	public EnemyHealthScript blueFishPrefab;
	public EnemyHealthScript redFishPrefab;
	public EnemyHealthScript duckPrefab;
	//public EnemyHealthScript Prefab;
	//public EnemyHealthScript Prefab;

	public Vector2 spawnAngelFishTime = new Vector2 (3.0f, 8.0f);
	public Vector2 spawnBlueFishTime = new Vector2 (4.0f, 8.0f);
	public Vector2 spawnRedFishTime = new Vector2 (4.0f, 8.0f);
	public Vector2 spawnDuckTime = new Vector2 (4.0f, 6.0f);

	public float spawnAngelFishCountdown = 2.0f;
	public float spawnBlueFishCountdown = 3.0f;
	public float spawnRedFishCountdown = 4.0f;
	public float spawnDuckCountdown = 5.0f;

	private const float SPAWN_X = 10f;
	private const float SPAWN_UNDERWATER_Y_MIN = -4.5f;   //set to 0 to turn off randomness
	private const float SPAWN_UNDERWATER_Y_MAX = 1.5f;   //-4 from random min point (0) is bottom of sea, 2 is on the surface
	private const float SPAWN_SURFACE_Y_OFFSET = 2.5f;

	public Transform spawner;

	private EnemyHealthScript angelFishInstance;
	private EnemyHealthScript blueFishInstance;
	// Use this for initialization
	void Start () {
		angelFishPrefab.CreatePool();
		blueFishPrefab.CreatePool();
		redFishPrefab.CreatePool();
		duckPrefab.CreatePool();
	
	}
	
	// Update is called once per frame
	void Update () {
		spawnAngelFishCountdown -= Time.deltaTime;
		if (spawnAngelFishCountdown <= 0)
		{
			spawnAngelFishCountdown = Random.Range(spawnAngelFishTime.x, spawnAngelFishTime.y);
			//enemyInstance = ObjectPool.Spawn(fish_dinner, new Vector3(10, Random.Range(-3f,1.3f),0));
			//spawner.position = new Vector3(SPAWN_X, Random.value*SPAWN_UNDERWATER_Y_RANGE + SPAWN_UNDERWATER_Y_OFFSET, 0);
			angelFishPrefab.Spawn(new Vector3(SPAWN_X, Random.Range(SPAWN_UNDERWATER_Y_MIN, SPAWN_UNDERWATER_Y_MAX), 0));
		}

		spawnBlueFishCountdown -= Time.deltaTime;
		if (spawnBlueFishCountdown <= 0)
		{
			spawnBlueFishCountdown = Random.Range(spawnBlueFishTime.x, spawnBlueFishTime.y);
			//enemyInstance = ObjectPool.Spawn(fish_dinner, new Vector3(10, Random.Range(-3f,1.3f),0));
			//spawner.position = new Vector3(SPAWN_X, Random.value*SPAWN_UNDERWATER_Y_RANGE + SPAWN_UNDERWATER_Y_OFFSET, 0);
			blueFishPrefab.Spawn(new Vector3(SPAWN_X, Random.Range(SPAWN_UNDERWATER_Y_MIN, SPAWN_UNDERWATER_Y_MAX), 0));
		}

		spawnRedFishCountdown -= Time.deltaTime;
		if (spawnRedFishCountdown <= 0)
		{
			spawnRedFishCountdown = Random.Range(spawnRedFishTime.x, spawnRedFishTime.y);
			//enemyInstance = ObjectPool.Spawn(fish_dinner, new Vector3(10, Random.Range(-3f,1.3f),0));
			//spawner.position = new Vector3(SPAWN_X, Random.value*SPAWN_UNDERWATER_Y_RANGE + SPAWN_UNDERWATER_Y_OFFSET, 0);
			redFishPrefab.Spawn(new Vector3(SPAWN_X, Random.Range(SPAWN_UNDERWATER_Y_MIN, SPAWN_UNDERWATER_Y_MAX), 0));
		}

		spawnDuckCountdown -= Time.deltaTime;
		if (spawnDuckCountdown <= 0)
		{
			spawnDuckCountdown = Random.Range(spawnDuckTime.x, spawnDuckTime.y);
			//enemyInstance = ObjectPool.Spawn(fish_dinner, new Vector3(10, Random.Range(-3f,1.3f),0));
			//spawner.position = new Vector3(SPAWN_X, Random.value*SPAWN_UNDERWATER_Y_RANGE + SPAWN_UNDERWATER_Y_OFFSET, 0);
			duckPrefab.Spawn(new Vector3(SPAWN_X, SPAWN_SURFACE_Y_OFFSET, 0));
		}
	
	}
}
