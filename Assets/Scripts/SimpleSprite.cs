using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSprite : MonoBehaviour {

	//Settables
	public Camera cam; // the camera.

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (cam.transform);
	}
}
