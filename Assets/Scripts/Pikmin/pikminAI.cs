using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class pikminAI : MonoBehaviour {
    public bool isWithPlayer = false;
    public bool isFlower = true;

    #region Singleton
    public static pikminAI instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    Transform playerT;
    NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        foreach (Transform t in CharacterMotor.instance.player.gameObject.transform)
        {
            if (t.name == "PikminPoint")
            {
                playerT = t;
                break;
            }
            else
            {
                playerT = CharacterMotor.instance.player.gameObject.transform;
            }
        }
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
    }
	
	void FixedUpdate () {
		StartCoroutine(pikChecks());
	}
    
	IEnumerator pikChecks() {
		if (isWithPlayer)
        {
            if (isFlower)
            {
                agent.acceleration = 16;
                agent.speed = 14;
            }
            agent.enabled = true;
            agent.SetDestination(playerT.position);
			yield return new WaitForSeconds(.2f);
        }
		else {
			yield return null;
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
