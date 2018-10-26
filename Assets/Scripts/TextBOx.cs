using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBOx : MonoBehaviour { 
    public float delay = 0.1f;
    public string fullText;
    public AudioClip audio;
    private string currentText = "";

    public IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            if (audio)
                this.GetComponent<AudioSource>().PlayOneShot(audio);
            yield return new WaitForSeconds(delay);
        }
    }
}
