using UnityEngine;
using System.Collections;
using System;

public class ScoreScript : MonoBehaviour {

	// <summary> How many points to increase per second </summary>
	public int scoreIncreaseSpeed = 100;

	private static int score = 0;
	private int renderedScore = 0;

	private GUIText scoreText;

	// Use this for initialization
	void Start () {
		scoreText = GameObject.Find("ScoreText").GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
		if (renderedScore < score) {
			renderedScore += (int)Math.Min(score - renderedScore, scoreIncreaseSpeed * Time.deltaTime);
		}

		scoreText.text = renderedScore.ToString();
	}

	public int addScore(int scoreToAdd) {
		score += scoreToAdd;
		return score;
	}

	public static int getScore() {
		return score;
	}

	public static void resetScore() {
		score = 0;
	}
}
