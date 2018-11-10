using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChild : MonoBehaviour {
	
	public bool playMusic;

	void FixedUpdate () {
		if (playMusic) {
			GetComponent<AudioSource> ().volume += .005f;
		}
		if (playMusic && !gameObject.GetComponent<AudioSource>().isPlaying) {
			gameObject.GetComponent<AudioSource> ().Play ();
		}
	}
}
