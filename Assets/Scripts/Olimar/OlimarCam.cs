using UnityEngine;
using System.Collections;

public class OlimarCam : MonoBehaviour {
	// Settables
	public float[] distancesUp = new float[] { 20f, 26f, 40f }, distancesAway = new float[] {15f, 25f, 35f }, FOVS = new float[] {15f, 25f, 35f }; // CLICK the right thumbstick to cycle through camera distances.
	public float positionEasing = 0.1f; // HIGHER means snappier. Lower is smoother.
	public float inputRotationSensitivity = 0.025f; // the lower this value, the less we can rotate the camera with the right thumbstick.
	// References
	[SerializeField]
	Transform myTarget;
	// Properties
	private int currentDistanceIndex; // CLICK the right thumbstick to cycle through camera distances.
	private float FOV;
	private float distanceUp;
	private float distanceAway;
	public float inputRotationVel; // rotate the camera with the right thumbstick.
	private Vector3 targetPosition; // where I aim to put myself (we ease into this position)
	private Camera cam; // the camera component of the object.

    /*private float[] disUp;
    private float[] disAw;
    private float[] disFo;*/
    private GameObject txt; // textbox object

    void Start () {
		//inputRotationVel = 0;
		SetCurrentDistanceIndex(1);
		cam = GetComponent<Camera> ();
        /*disUp = distancesUp;
        disAw = distancesAway;
        disFo = FOVS;*/
        txt = GameObject.Find("Starting Text");
    }

	void Update() {
		// Change camera distance!
		if (Input.GetButtonDown("Right Stick Click")) {
			SetCurrentDistanceIndex(currentDistanceIndex + 1);
		}
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(txt.GetComponent<textBox>().ShowText());
        }
	}

	void SetCurrentDistanceIndex(int newIndex) {
		currentDistanceIndex = newIndex;
		if (currentDistanceIndex >= distancesAway.Length) {
			currentDistanceIndex = 0;
		}
		distanceUp = distancesUp[currentDistanceIndex];
		distanceAway = distancesAway[currentDistanceIndex];
		FOV = FOVS [currentDistanceIndex];
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
		cam.fieldOfView = FOV;

		// Look at my target!
		transform.LookAt (myTarget);
	}
}



