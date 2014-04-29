using UnityEngine;
using System.Collections;

public class StuffDropper : MonoBehaviour {

	public Projectile projectilePrefab;
	public Vector2 projectileSpawnTime = new Vector2 (3.0f, 8.0f);
	public Vector2 projectileSpawnOffset = Vector2.zero;
	public int maxDrops = -1;
	public Vector2 initialForce = new Vector2(0f,0f);
	public string attackAnimation = "ThrowCan";
	public float dropDelay = 0f;

	private Animator animator;
	private float projectileSpawnCountdown = 5.0f;
	private int numDropped = 0;
	private bool isDropping = false;

	void Awake () {
		numDropped = 0;
	}

	// Use this for initialization
	void Start () {
		if (null != projectilePrefab) {
			//projectilePrefab.CreatePool ();
			projectileSpawnCountdown = Random.Range(projectileSpawnTime.x, projectileSpawnTime.y);
		}
		
		numDropped = 0;
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (null != projectilePrefab) {
			projectileSpawnCountdown -= Time.deltaTime;

			if (projectileSpawnCountdown <= 0 && (maxDrops == -1 || numDropped < maxDrops) && !isDropping) {
				if (null != animator && null != attackAnimation) {
					animator.SetTrigger(attackAnimation);
				}
				isDropping = true;
			}

			if (isDropping && projectileSpawnCountdown <= -dropDelay) {
				Projectile p = projectilePrefab.Spawn(transform.position + Vector3.down*projectileSpawnOffset.y + Vector3.right*projectileSpawnOffset.x);
				p.rigidbody2D.AddForce(initialForce);
				
				projectileSpawnCountdown = Random.Range(projectileSpawnTime.x, projectileSpawnTime.y);

				isDropping = false;
				numDropped++;
			}
		}
	}
}
