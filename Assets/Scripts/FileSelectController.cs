using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class FileSelectController : MonoBehaviour {

    public Button[] buttons;
    private Animator anim;
    private bool loadingLevel;

    void Start()
    {
        buttons[0].onClick.AddListener(delegate { whenClicked(buttons[0].gameObject, 0); });
        buttons[1].onClick.AddListener(delegate { whenClicked(buttons[1].gameObject, 1); });
        buttons[2].onClick.AddListener(delegate { whenClicked(buttons[2].gameObject, 2); });
    }

    void whenClicked(GameObject button, int index)
    {
        anim = button.GetComponent<Animator>();
        anim.SetBool("Clicked", true);
        
    }
}
