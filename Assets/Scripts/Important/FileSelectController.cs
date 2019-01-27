﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FileSelectController : MonoBehaviour {

    public Button[] buttons;
    public GameObject canvas;
    public GameObject loading;
    public GameObject fadeObject;
    public bool skipMovie;
    Animator anim;
    bool loadingLevel;
    AsyncOperation asyncLoad;

    void Start()
    {
        loading.SetActive(false);
        buttons[0].onClick.AddListener(delegate { whenClicked(buttons, 0); });
        buttons[1].onClick.AddListener(delegate { whenClicked(buttons, 1); });
        buttons[2].onClick.AddListener(delegate { whenClicked(buttons, 2); });
    }

    void whenClicked(Button[] buttons, int index)
    {
        StartCoroutine(whenClickedMainFunc(index)); // start the ienumerator
    }

    IEnumerator whenClickedMainFunc(int index)
    {
        GameObject currButton = buttons[index].gameObject; // get current button gameobject using buttons[index (which is a number)].gameObject
        anim = currButton.GetComponent<Animator>(); // get its animator
        anim.SetBool("Clicked", true); // clicked
        yield return new WaitForSeconds(.1f);
        anim.SetBool("Clicked", false); // let animation play out
        buttons[0].onClick.RemoveAllListeners(); // remove all click functionality
        buttons[1].onClick.RemoveAllListeners(); // ^^
        buttons[2].onClick.RemoveAllListeners(); // ^^
        yield return new WaitForSeconds(.5f); // wait for animation to play 
        if (skipMovie)
        {
            StartCoroutine(LoadImpactSite());
        }
        else
        {
            fadeObject.GetComponent<FadeCamera>().FadeOut(); // fade out
            yield return new WaitForSeconds(1f); // wait until faded to black
            canvas.SetActive(false);
            //add start movie functionality here :D
        }
    }

    IEnumerator LoadImpactSite()
    {
        fadeObject.GetComponent<FadeCamera>().FadeOut(); // fade out
        yield return new WaitForSeconds(3f); // wait for this many seconds
        StartCoroutine(loadScene()); // start loading cutscene
        yield return new WaitForSeconds(1);
        GameObject.Destroy(canvas.gameObject); // destroy old canvas
        loading.SetActive(true); // activate text
        fadeObject.GetComponent<FadeCamera>().FadeIn(); // fade in
        yield return new WaitForSeconds(4);
        asyncLoad.allowSceneActivation = true; // allow loading into scene!
    }

    IEnumerator loadScene()
    {
        Debug.LogWarning("SCENE LOAD START ! ! ! !"); // does a warning stating that the scene loading has started
        asyncLoad = SceneManager.LoadSceneAsync("Scenes/ImpactSite/ImpactSite"); // load this scene from the scene index
        asyncLoad.allowSceneActivation = false; // dont let it load straight into it
        yield return asyncLoad; // dunno what this does lol
    }
}
