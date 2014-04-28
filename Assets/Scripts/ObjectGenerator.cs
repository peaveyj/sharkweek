using UnityEngine;
using System.Collections;

public class ObjectGenerator : MonoBehaviour {

	public EnemyHealthScript angelFishPrefab;
	public EnemyHealthScript blueFishPrefab;
	public EnemyHealthScript redFishPrefab;
	public EnemyHealthScript duckPrefab;
	public EnemyHealthScript tubePrefab;
	public EnemyHealthScript surferPrefab;

	public Vector2 spawnAngelFishTime = new Vector2 (3.0f, 8.0f);
	public Vector2 spawnBlueFishTime = new Vector2 (4.0f, 8.0f);
	public Vector2 spawnRedFishTime = new Vector2 (4.0f, 8.0f);
	public Vector2 spawnDuckTime = new Vector2 (4.0f, 6.0f);
	public Vector2 spawnTubeTime = new Vector2 (4.0f, 6.0f);
	public Vector2 spawnSurferTime = new Vector2 (4.0f, 6.0f);

	public float spawnAngelFishCountdown = 2.0f;
	public float spawnBlueFishCountdown = 3.0f;
	public float spawnRedFishCountdown = 4.0f;
	public float spawnDuckCountdown = 5.0f;
	public float spawnTubeCountdown = 5.0f;
	public float spawnSurferCountdown = 5.0f;

	private const float SPAWN_X = 10f;
	public float SPAWN_UNDERWATER_Y_MIN = -4.5f;
	public float SPAWN_UNDERWATER_Y_MAX = 1.5f;
	private const float SPAWN_SURFACE_Y_OFFSET = 2.0f;
	public float DUCK_VERT_TWEAK = 0f;
	public float TUBE_VERT_TWEAK = .3f;
	public float SURFER_VERT_TWEAK = 1.0f;
	
	// Use this for initialization
	void Start () {
		angelFishPrefab.CreatePool();
		blueFishPrefab.CreatePool();
		redFishPrefab.CreatePool();
		duckPrefab.CreatePool();
		tubePrefab.CreatePool();
		surferPrefab.CreatePool();	
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
		spawnTubeCountdown -= Time.deltaTime;
		if (spawnTubeCountdown <= 0)
		{
			spawnTubeCountdown = Random.Range(spawnTubeTime.x, spawnTubeTime.y);
			//enemyInstance = ObjectPool.Spawn(fish_dinner, new Vector3(10, Random.Range(-3f,1.3f),0));
			//spawner.position = new Vector3(SPAWN_X, Random.value*SPAWN_UNDERWATER_Y_RANGE + SPAWN_UNDERWATER_Y_OFFSET, 0);
			tubePrefab.Spawn(new Vector3(SPAWN_X, SPAWN_SURFACE_Y_OFFSET-TUBE_VERT_TWEAK, 0));
		}
		spawnSurferCountdown -= Time.deltaTime;
		if (spawnSurferCountdown <= 0)
		{
			spawnSurferCountdown = Random.Range(spawnSurferTime.x, spawnSurferTime.y);
			//enemyInstance = ObjectPool.Spawn(fish_dinner, new Vector3(10, Random.Range(-3f,1.3f),0));
			//spawner.position = new Vector3(SPAWN_X, Random.value*SPAWN_UNDERWATER_Y_RANGE + SPAWN_UNDERWATER_Y_OFFSET, 0);
			surferPrefab.Spawn(new Vector3(SPAWN_X, SPAWN_SURFACE_Y_OFFSET+SURFER_VERT_TWEAK, 0));
		}

	}
}
