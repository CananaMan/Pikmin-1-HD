using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChappyAnimHandler : MonoBehaviour { // basic start of animation handling for the ai
	
	private Animator animHandler;
	private bool playerFound;
	public bool isSleeping = true;
	public bool isEating = false;
	public bool isWalking = false;
	
	// Use this for initialization
	void Start () {
		animHandler = this.GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update () {
		StartCoroutine(animUpdateRepeated());
	}
	
	
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Pikmin") { // if the collided is the player or pikmin
			isSleeping = false;
			isWalking = true;
			playerFound = true;
		}
	}
	
	void OnTriggerExit(Collider col) { // on trigger exit
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Pikmin") {
			isSleeping = false;
			isWalking = true;
			playerFound = false;
			StartCoroutine(timeUntilLost(2)); // start the timeUntilLost ienumerator.
		}
	}
	
	void animUpdate() { //updates the anims to the boolean values
		animHandler.SetBool("isSleep", isSleeping);
		animHandler.SetBool("isEating", isEating);
		animHandler.SetBool("isWalking", isWalking);
	}
	
	IEnumerator animUpdateRepeated() { // this allows for a lot less calls which is optimization.
		animUpdate();
		yield return new WaitForSeconds(.2f);
	}
	
	IEnumerator timeUntilLost(int time) { //takes time until player or pikmin lost
		if (playerFound) { // if the player has been found. get out of the function
			yield return null;
		}
		else { //if it hasnt been found
			isWalking = false; // stop walking
			yield return new WaitForSeconds(time); // wait for that amount of time
			isSleeping = true; // start sleeping again.
		}
	}
}
