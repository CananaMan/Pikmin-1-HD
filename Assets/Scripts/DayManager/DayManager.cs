﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{

    public GameObject dayImage;
    public AudioClip[] music;
    public int second;
    public int daySpeed = 1;
    public int dayState = 1; // 11 = morning undone, 12 = morning done , 22 = afternoon undone, 23 = afternoon done, 33 = noon undone, 34 = noon done, 4 = ended.
    private AudioSource thisAudio;
    // Use this for initialization
    void Start()
    {
        thisAudio = this.GetComponent<AudioSource>();
        //Debug.Log ("The position of the day object is:" + dayPos.ToString ());
        InvokeRepeating("secondTick", .1f, 1); // repeat this 0.1 seconds after every 1 second.
        Camera.main.gameObject.GetComponent<FadeCamera>().FadeIn();
    }

    void secondTick()
    { 
        second = daySpeed + second;
        Vector3 dayPos = new Vector3
            (
            dayImage.GetComponent<RectTransform>().position.x + daySpeed * Time.deltaTime,
            dayImage.GetComponent<RectTransform>().position.y,
            dayImage.GetComponent<RectTransform>().position.z
            );
        dayImage.GetComponent<RectTransform>().position = dayPos;
        if (second <= 530)
        { // if it is less than 530 seconds its morning
            if (dayState == 12)
                return;
            else 
                dayState = 11;
        }
        if (second >= 530 && second <= 900)
        { // if its more than 530 seconds and less than 900 its afternoon
            if (dayState == 23)
                return;
            else
                dayState = 22; thisAudio.loop = false;
        }
        if (second >= 900)
        { // if its more than 900 its night
            if (dayState == 34)
                return;
            else
                dayState = 33; thisAudio.loop = false;
        }
        if (second >= 1060)
        {
            dayState = 4;
            CancelInvoke(); // stop the clock (night time is here therefore we dont need it anymore)
        }
    }

    void musicPlay()
    {
        if (dayState == 11 && !thisAudio.isPlaying) // if its morning and the audio isnt playing
        {
            thisAudio.clip = music[0];
            StartCoroutine(fadeIn());
            dayState = 12; // morning music started
        }

        if (dayState == 22 && !thisAudio.isPlaying) { //day undone and isnt playing
            thisAudio.clip = music[1]; // put main in the clip
            StartCoroutine(fadeIn()); // play it repeatedly
            dayState = 23; // music is now playing
        }

        if (dayState == 33 && !thisAudio.isPlaying)
        {
            thisAudio.clip = music[2];
            StartCoroutine(fadeIn());
            dayState = 34;
        }

        if (dayState == 4 && !thisAudio.isPlaying)
            thisAudio.Stop();
    }

    IEnumerator fadeIn()
    {
        thisAudio.volume = 0.0f;
        thisAudio.Play();
        thisAudio.loop = true;
        float t = 0.0f;
        while (t < .5f)
        {
            t += 0.0005f;
            thisAudio.volume = t;
            yield return new WaitForSeconds(0);
        }
    }

    void LateUpdate()
    {
        if (dayState == 4)
        {
            Debug.Break();
            Debug.Log("Need to program in night ending sequence");
        }
        musicPlay();
    }
}
