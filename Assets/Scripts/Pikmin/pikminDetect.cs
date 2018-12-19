using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class pikminDetect : MonoBehaviour {

    public GameObject[] pikminSquad;
    public int pikminCount = 0;

    void OnTriggerEnter(Collider col)
    {
        GameObject colGameObject = col.gameObject;
        if (colGameObject.tag == "Pikmin")
        {
            // check for the pikmin instance in the array
            if (pikminSquad.Contains(colGameObject))
            {
                print("already in squad");
                colGameObject = null;
                col = null;
            }
            else
            {
                pikminSquad[pikminCount] = colGameObject;
                colGameObject.GetComponent<pikminAI>().isWithPlayer = true;
                pikminCount++;
            }
        }
    }
}
