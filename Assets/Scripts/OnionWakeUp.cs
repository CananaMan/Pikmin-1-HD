using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnionWakeUp : MonoBehaviour {

	public Animator animHandler;
    public GameObject player;

	IEnumerator waitUntilEnd() {

		animHandler.SetBool ("InTrigger", true);
		yield return new WaitForSeconds (5.1f);
		animHandler.SetBool ("CutScenePlayed", true);
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			StartCoroutine (waitUntilEnd ());
		}
	}

}
