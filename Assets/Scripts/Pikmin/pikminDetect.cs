using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class pikminDetect : MonoBehaviour {
    //Meant for whistlebody
    private List<GameObject> pikminSquad;
    public int pikminCount = 0;

    #region Singleton
    public static pikminDetect instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public void insertPikmin(int count, GameObject pikmin, GameObject colGameObject)
    {
        // check for the pikmin instance in the array
        if (pikminSquad.Contains(colGameObject))
        {
            colGameObject = null;
            return;
        }
        else if (colGameObject == null)
        {
            return;
        }
        colGameObject.GetComponent<pikminAI>().isWithPlayer = true;
        pikminSquad.Insert(count, pikmin);
        pikminCount++;
        
    }

    void Start()
    {
        pikminSquad = PikminManager.instance.manager.gameObject.GetComponent<PikminManager>().pikminInSquad;
    }

    void OnTriggerEnter(Collider col)
    {
        GameObject colGameObject = col.gameObject;
        if (colGameObject.tag == "Pikmin")
        {
            insertPikmin(pikminCount, colGameObject, colGameObject);
        }
    }
}
