using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

	// Settables
	public GameObject whiteFlowerObject; // put the main menu flower prefab here.
	public GameObject sunObject; // put the sun object here.
	public Color startColor, endColor; // specify the start and end colors here.
	private Color currentColor; // the current color of the sun light;
	public float endIntensity, duration; // the end intensity of the sun light, the duration of the main menu "day".
	public float changeRate, changeSmoothness; // the rate of change of the sun light color and intensity, the smoothness between the changeRates; larger values are choppier, smaller values are smoother.

	private Light sunLight; // the light from the sun object;

	// Use this for initialization
	void Start () {
		sunLight = sunObject.GetComponent<Light> ();
		sunLight.color = startColor;

		StartCoroutine ("SunColor");
	}

	IEnumerator SunColor () {
		while (true) {
			currentColor = sunLight.color; // sets the current color as the sun color.
			sunLight.color = Color.Lerp (currentColor, endColor, changeRate); // blends between the current color and the end color. if it blended between start and end colors, it would flicker between the two rapidly.
			if (sunLight.color == endColor && sunLight.intensity == endIntensity)
				StopCoroutine ("Background");

			if (sunLight.intensity > 0 && sunLight.color == endColor)
				sunLight.intensity -= changeRate;
			
			yield return new WaitForSeconds (changeSmoothness);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
