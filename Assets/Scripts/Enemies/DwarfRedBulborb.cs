using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfRedBulborb : MonoBehaviour {

	// Settables
	public int rangeX = 2, rangeY = 3; // this is the enemy's range settings.


	public Transform target; // this is the enemy's target. 
	private CapsuleCollider range; // this is the enemy's actual range.

	// Use this for initialization
	void Start () {
		range = GetComponent<CapsuleCollider> ();

		range.radius = rangeX;
		range.height = rangeY;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3.MoveTowards (gameObject.transform.position, target.position, 1f);
		print ("test");
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player" || other.tag == "Pikmin") {
			target = other.transform;
		}
	}
}
