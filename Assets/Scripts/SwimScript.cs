﻿using UnityEngine;
using System.Collections;
using System;

public class SwimScript : MonoBehaviour {

	// <summary> Upward force of a swim </summary>
	public float swimForce = 5.0f;
	// <summary> Time between swims </summary>
	public float swimRate = 0.5f;
	// <summary> Y position of the top of the water </summary>
	public float topOfWaterPoint = 1.3f;
	// <summary> Y position at which the shark will just stay if you don't swim upward </summary>
	public float swimPoint = -3.0f;
	// <summary> Cooldown in seconds between swims </summary>
	public float swimCooldown = 0f;
	// <summary> Multiplier for gravity when out of the water </summary>
	public float outOfWaterGravityModifier = 3.0f;

	private float startingGravity;
	private float startingDrag;

	void Awake() {
		startingGravity = rigidbody2D.gravityScale;
		startingDrag = rigidbody2D.drag;
	}

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		if (swimCooldown > 0) {
			swimCooldown -= Time.deltaTime;
		}
	}

    void FixedUpdate() {

		if (transform.position.y <= swimPoint) {
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.gravityScale = 0;
			transform.position = new Vector2(transform.position.x, swimPoint);
		}

		if (transform.position.y >= topOfWaterPoint) {
			rigidbody2D.gravityScale = startingGravity * outOfWaterGravityModifier;
			rigidbody2D.drag = 0;
		} else {
			rigidbody2D.gravityScale = startingGravity;
			rigidbody2D.drag = startingDrag;
		}

		// Swim
		if (CanSwim && Input.GetButtonDown("Jump")) {
			swimCooldown = swimRate;
			rigidbody2D.velocity = Vector2.up * swimForce;
			rigidbody2D.gravityScale = startingGravity;
		}
    }

	// <summary> Is the shark ready to swim again? </summary>
	public bool CanSwim { get { return (swimRate <= 0f || swimCooldown <= 0f) && transform.position.y < topOfWaterPoint; } }
}
