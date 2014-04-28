using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {
	// 1 - Designer variables
	
	/// <summary>
	/// Object speed
	/// </summary>
	public Vector2 speed = new Vector2(10, 10);
	
	/// <summary>
	/// Moving direction
	/// </summary>
	public Vector2 direction = new Vector2(-1, 0);
	
	private Vector2 movement;
	private Sprite sprite;

	void Awake() {
		sprite = GetComponent<SpriteRenderer>().sprite;
	}

	void Update()
	{
		// 2 - Movement
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);

		/*
		if (direction.x < 0 && transform.position.x < 0) {
			Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
			bool isVisible = GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
			if (!isVisible) {
				Destroy(gameObject, 0.5f);
			}
		}
		*/
	}
	
	void FixedUpdate()
	{
		// Apply movement to the rigidbody
		rigidbody2D.velocity = movement;
	}
}
