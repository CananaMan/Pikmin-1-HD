using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class FileSelectController : MonoBehaviour {

    public Button[] buttons;
    public GameObject canvas;
    private Animator anim;
    private bool loadingLevel;

    void Start()
    {
        buttons[0].onClick.AddListener(delegate { whenClicked(buttons, 0); });
        buttons[1].onClick.AddListener(delegate { whenClicked(buttons, 1); });
        buttons[2].onClick.AddListener(delegate { whenClicked(buttons, 2); });
    }

    void whenClicked(Button[] buttons, int index)
    {
        StartCoroutine(whenClickedMainFunc());
    }

    void loadFilm()
    {

    }

    IEnumerator whenClickedMainFunc()
    {
        GameObject currButton = buttons[index].gameObject; // get current button gameobject using buttons[index (number)].gameObject
        anim = currButton.GetComponent<Animator>(); // get its animator
        anim.SetBool("Clicked", true); // clicked
        yield return new WaitForSeconds(.1f);
        anim.SetBool("Clicked", false); // let animation play out
        buttons[0].onClick.RemoveAllListeners(); // remove all click functionality
        buttons[1].onClick.RemoveAllListeners(); // ^^
        buttons[2].onClick.RemoveAllListeners(); // ^^
        yield return new WaitForSeconds(.5f); // wait for animation to play 
        FadeCamera.instance.FadeOut(); // fade out
        yield return new WaitForSeconds(1f); // wait until faded to black


    }
}
