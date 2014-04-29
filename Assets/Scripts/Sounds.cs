using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour {

	private AudioSource[] sounds = new AudioSource[1];

	// Use this for initialization
	void Awake () {
		 sounds = GameObject.FindObjectsOfType<AudioSource> ();
	}

	public void Play(string name) {
		for (int i = 0; i < sounds.Length; i++) {
			if (sounds[i].clip.name == name) {
			    sounds[i].Play();
				break;
			}
		}
	}
}
