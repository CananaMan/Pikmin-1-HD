using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class pikminAI : MonoBehaviour {
    public bool isWithPlayer = false;
    public bool isFlower = true;

    Transform playerT;
    NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        foreach (Transform t in playerSingleton.instance.player.gameObject.transform)
        {
            if (t.name == "PikminPoint")
            {
                playerT = t;
                break;
            }
            else
            {
                playerT = playerSingleton.instance.player.gameObject.transform;
            }
        }
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

		if (isWithPlayer)
        {
            if (isFlower)
            {
                agent.acceleration = 12;
                agent.speed = 8;
            }
            agent.enabled = true;
            agent.SetDestination(playerT.position);
        }
	}
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            isWithPlayer = true;
            pikminDetect.instance.gameObject.GetComponent<pikminDetect>().insertPikmin(pikminDetect.instance.gameObject.GetComponent<pikminDetect>().pikminCount, this.gameObject, null);
        }
    }
}
