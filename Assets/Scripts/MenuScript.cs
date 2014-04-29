using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	public string buttonText = "Shark!";

	void OnGUI()
	{
		const int buttonWidth = 84;
		const int buttonHeight = 60;
		
		// Draw a button to start the game
		if (
			GUI.Button(
				// Center in X, 2/3 of the height in Y
				new Rect(
					Screen.width * 0.8f,
					Screen.height/2 - buttonHeight/2,
					buttonWidth,
					buttonHeight
					),
					buttonText
				)
			)
		{
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			ScoreScript.resetScore();
			Application.LoadLevel("Stage1");
		}
	}
}
