using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour {

	public GameObject dayImage;
	public GameObject secondaryMusicObject;
	public AudioClip[] music;
	public int dayTime;
	public int second;
	public int daySpeed = 1;
	public bool isNight;
	public bool isAfternoon;
	public bool isMorning;
    private bool dayDone = false;

    // Use this for initialization
    void Start()
    {
        //Debug.Log ("The position of the day object is:" + dayPos.ToString ());
        InvokeRepeating("secondTick", .1f, 1); // repeat this 0.1 seconds after every 1 second.

    }

    void secondTick() { // Need to optimize this function, not sure how to :/
		second = daySpeed + second;
		Vector3 dayPos = new Vector3
            (
            dayImage.GetComponent<RectTransform>().position.x + daySpeed,
			dayImage.GetComponent<RectTransform>().position.y,		
			dayImage.GetComponent<RectTransform>().position.z
            );
		dayImage.GetComponent<RectTransform> ().position = dayPos;
		if (second <= 530) { // if it is less than 530 seconds its morning
			isMorning = true;
			isAfternoon = false;
			isNight = false;
		}
		if (second >= 530 && second <= 900) { // if its more than 530 seconds and less than 900 its afternoon
			isMorning = false;
			isNight = false;
			isAfternoon = true;
		}
		if (second >= 900) { // if its more than 900 its night
			isNight = true;
			isAfternoon = false;
			isMorning = false;
	
		}
		if (second >= 1060) {
			isNight = false; 
			isMorning = false;
			isAfternoon = false;
            dayDone = true;
			CancelInvoke (); // stop the clock (night time is here therefore we dont need it anymore)
		}
	}

	void musicPlay() {
        bool loadedMusicTwo = false;
        bool twoComplete = false;

        var thisAudio = GetComponent<AudioSource>();
        var childAudio = secondaryMusicObject.GetComponent<AudioSource>();
        var childScript = secondaryMusicObject.GetComponent<MusicChild>();

        if (isMorning && !thisAudio.isPlaying) { // If its morning and no audio is playing
			thisAudio.clip = music [0]; // input the first audio clip in the array
			thisAudio.Play (); // play it
		}

		if (isAfternoon && !twoComplete) {// if its afternoon and two is complete(???)
			if (!loadedMusicTwo) {
				childAudio.clip = music [1]; // load in the new music clip
				loadedMusicTwo = true;
			}
			if (childAudio.volume != 1) {
				childAudio.volume += 0.05f; // fade in new music effect
				thisAudio.volume -= 0.05f; // fade out old music effect
			}
			if (childAudio.volume == 1) {
				twoComplete = true;
			}
		}

		if (isAfternoon && twoComplete) {
			childScript.playMusic = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (dayDone) {
			Debug.Break ();
			Debug.Log ("Need to program in night ending sequence");
		}
		musicPlay ();
	}
}
