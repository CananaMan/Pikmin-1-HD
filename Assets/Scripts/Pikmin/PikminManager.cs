using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikminManager : MonoBehaviour {
    #region Singleton
    public static PikminManager instance;
    void Awake()
    {
        foreach (Transform t in CharacterMotor.instance.player.gameObject.transform)
        {
            if (t.name == "PikminPoint")
            {
                PikminPoint = t;
                break;
            }
        }
        PikminPoint.transform.position = PikminArrangementObjects[0].transform.position;
        InvokeRepeating("checkPikCount", .1f, .1f);
        instance = this;
        manager = this.gameObject;
    }
    #endregion
    public List<GameObject> pikminInSquad;// how many pikmin are in squad
    public GameObject[] PikminArrangementObjects; // what objects the pikmin go towards (there should only be 2)
    [HideInInspector]
    public GameObject manager;
    private pikminAI pai;
    private pikminDetect paid;

    private Transform PikminPoint;
    bool oneTime = false; // temp var

    void Start()
    {
        pai = pikminAI.instance;
        paid = pikminDetect.instance;
    }

    void FixedUpdate()
    {
        disbandPikiBand();
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

    void disbandPikiBand()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            for (int i = 0; i < pikminInSquad.Count; i++)
            {
                pikminInSquad[i].gameObject.GetComponent<pikminAI>().isWithPlayer = false;
            }
            paid.pikminCount = 0;
            pikminInSquad.Clear();
        }
    }
}
