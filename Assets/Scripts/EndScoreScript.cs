using UnityEngine;
using System.Collections;

public class EndScoreScript : MonoBehaviour {

	private GUIText scoreText;

	// Use this for initialization
	void Start () {
		scoreText = GameObject.Find("ScoreText").GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "You've eaten " + ScoreScript.getScore() + " shark points worth of sea life before you blew up.";
	}
}
