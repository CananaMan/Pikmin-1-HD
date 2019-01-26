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

    private pikminDetect paid;
    private Transform PikminPoint;
    bool oneTime = false; // temp var

    void Start()
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
        paid = pikminDetect.instance;
        InvokeRepeating("checkPikCount", .3f, .3f);
    }

    void FixedUpdate()
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

    void checkPikCount()
    {
        if (pikminInSquad.Count <= 25)
        {
            PikminPoint.transform.position = PikminArrangementObjects[0].transform.position;
        }
        if (pikminInSquad.Count <= 49 && pikminInSquad.Count >= 26)
        {
            PikminPoint.transform.position = PikminArrangementObjects[1].transform.position;
            oneTime = false;
        }
        if (pikminInSquad.Count >= 50 && !oneTime)
        {
            PikminPoint.transform.position = PikminArrangementObjects[2].transform.position;
            oneTime = true;
        }
    }
}
