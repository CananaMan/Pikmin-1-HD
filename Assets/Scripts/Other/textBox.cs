using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textBox : MonoBehaviour { 
    public float delay = 0.1f;
    public string fullText;
    new public AudioClip audio;
    public string currentText = "";

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

    void Update()
    {
        //Debug.Log(this.GetComponent<Text>().text.Length.ToString() == fullText.Length.ToString() + "text.length + fulltext.length");
        //Debug.Log(fullText.Length + "fulltext.length");
        //Debug.Log(this.GetComponent<Text>().text.Length + "text.length");

        if (this.GetComponent<Text>().text.Length == fullText.Length)
        {
            this.GetComponent<Text>().text = null;
        }
    }
}
