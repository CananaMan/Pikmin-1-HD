using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikminManager : MonoBehaviour {
    #region Singleton
    public static PikminManager instance;

    void Awake()
    {
        instance = this;
        manager = this.gameObject;
    }
    #endregion
    public List<GameObject> pikminInSquad;// how many pikmin are in squad
    public GameObject[] PikminArrangementObjects; // what objects the pikmin go towards (there should only be 2)

    [HideInInspector]
    public GameObject manager;

    private Transform PikminPoint;

    bool oneTime = false; // temp var

    // Use this for initialization
    void Start()
    {
        foreach (Transform t in playerSingleton.instance.player.gameObject.transform)
        {
            if (t.name == "PikminPoint")
            {
                PikminPoint = t;
                break;
            }
        }
        PikminPoint.transform.position = PikminArrangementObjects[0].transform.position;
        InvokeRepeating("checkPikCount", .1f, .1f);
    }

    void checkPikCount()
    {
        if (pikminInSquad.Count >= 50 && !oneTime)
        {
            PikminPoint.transform.position = PikminArrangementObjects[1].transform.position;
            oneTime = true;
        }
        if (pikminInSquad.Count <= 49)
        {
            oneTime = false;
        }
    }
}
