using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class formationMgr : MonoBehaviour
{
    public List<GameObject> pikiInForm; // all pikmin that have a formation position
    private bool isInPos; // bool to detect if pikmin[i] are in formation
    public bool goToOriginFormation; // If this gets called then they have to go to the original formation
    public float[] posTable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
