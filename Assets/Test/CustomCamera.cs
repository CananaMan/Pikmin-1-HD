using UnityEngine;
using System.Collections;

public class CustomCamera : MonoBehaviour {
	// Settables
	private float[] distancesUp = new float[] { 6f, 8f, 10f }; // CLICK the right thumbstick to cycle through camera distances.
	private float[] distancesAway = new float[] { 8f, 14f, 20f }; // CLICK the right thumbstick to cycle through camera distances.
	private float positionEasing = 1f; // HIGHER means snappier. Lower is smoother.
	private float inputRotationSensitivity = 0.025f; // the lower this value, the less we can rotate the camera with the right thumbstick.
	// References
	[SerializeField]
	Transform myTarget;
	// Properties
	private int currentDistanceIndex; // CLICK the right thumbstick to cycle through camera distances.
	private float distanceUp;
	private float distanceAway;
	private float inputRotationVel; // rotate the camera with the right thumbstick.
	private Vector3 targetPosition; // where I aim to put myself (we ease into this position)

	void Start () {
		inputRotationVel = 0;
		SetCurrentDistanceIndex(1);
	}

	void Update() {
		// Change camera distance!
		if (Input.GetButtonDown("Right Stick Click")) {
			SetCurrentDistanceIndex(currentDistanceIndex + 1);
		}
	}

	void SetCurrentDistanceIndex(int newIndex) {
		currentDistanceIndex = newIndex;
		if (currentDistanceIndex >= distancesAway.Length) {
			currentDistanceIndex = 0;
		}
		distanceUp = distancesUp[currentDistanceIndex];
		distanceAway = distancesAway[currentDistanceIndex];
    }
	
	void FixedUpdate () {
		float angleToTarget = Mathf.Atan2 (transform.position.z-myTarget.position.z, transform.position.x-myTarget.position.x);

		// Accept input to rotate, yo!
		inputRotationVel *= 0.92f;
		inputRotationVel -= Input.GetAxis("RightX") * inputRotationSensitivity;
		if (inputRotationVel > 0.6f) inputRotationVel = 0.6f;
		if (inputRotationVel < -0.6f) inputRotationVel = -0.6f;
		transform.position += new Vector3(-Mathf.Sin (angleToTarget)*inputRotationVel, 0, Mathf.Cos (angleToTarget)*inputRotationVel);

		// Move to a nice position!
		targetPosition = myTarget.position + Vector3.up*distanceUp + new Vector3(Mathf.Cos (angleToTarget)* distanceAway, 0, Mathf.Sin (angleToTarget)* distanceAway);
		transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime*positionEasing);

		// Look at my target!
		transform.LookAt (myTarget);
	}
}



