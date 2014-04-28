using UnityEngine;
using System.Collections;

public class ObjectGenerator : MonoBehaviour {

	public MoveScript fish_dinner;
	public float spawnDinnerTime = 3;
	private float spawnDinnerCountdown = 0;

	public MoveScript enemyInstance;
	// Use this for initialization
	void Start () {
		ObjectPool.CreatePool (fish_dinner);

	
	}
	
	// Update is called once per frame
	void Update () {
		spawnDinnerCountdown -= Time.deltaTime;
		if (spawnDinnerCountdown <= 0)
		{
			spawnDinnerCountdown = spawnDinnerTime;
			enemyInstance = ObjectPool.Spawn(fish_dinner, new Vector3(10, Random.Range(-3f,1.3f),0));
		}
	
	}
}
