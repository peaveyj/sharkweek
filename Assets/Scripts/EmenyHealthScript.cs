﻿using UnityEngine;
using System.Collections;

public class EmenyHealthScript : MonoBehaviour {

	public int health = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		if (otherCollider.gameObject.name == "shark_head") {
			health--;
			if (health <= 0) {
				Destroy(gameObject, 0.5f);
			}
		}
	}
}
