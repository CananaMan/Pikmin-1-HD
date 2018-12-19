using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class pikminAI : MonoBehaviour {

    public bool isWithPlayer = false;
    Transform playerT;
    NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        playerT = playerSingleton.instance.player.gameObject.transform;
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

		if (isWithPlayer)
        {
            float distance = Vector3.Distance(playerT.position, transform.position);

            agent.SetDestination(playerT.position);
        }
        else
        {
            agent.enabled = false;
        }
	}
}
