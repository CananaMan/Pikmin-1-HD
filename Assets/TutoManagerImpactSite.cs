using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoManagerImpactSite : MonoBehaviour {
    public GameObject camera;
    public GameObject player;
    public GameObject whistle;
    private Camera mainCam;
    void Start () {
        mainCam = camera.GetComponent<Camera>(); // camera definitioningiongiong
        //Olimar definition
        if (player.name == null)
        {
            if (GameObject.Find("Olimar") == null)
                player = GameObject.Find("Player");

            if (GameObject.Find("Player") == null)
                player = GameObject.Find("Olimar");
        }
        ((Behaviour)player.GetComponent("CharacterMotor")).enabled = false;
        ((Behaviour)player.GetComponent("PlatformInputController")).enabled = false;
        whistle.SetActive(false);

    }

}
