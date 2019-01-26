using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class pikminAI : MonoBehaviour {
    public bool isWithPlayer = false;
    public bool isFlower = true;

    [HideInInspector]
    public Transform playerT;
    [HideInInspector]
    public NavMeshAgent agent;

    #region Singleton
    public static pikminAI instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

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

    void FixedUpdate()
    {
        StartCoroutine(pikChecks());
    }

	IEnumerator pikChecks() {
        if (isWithPlayer)
        {
            if (isFlower)
            {
                agent.acceleration = 18;
                agent.speed = 16;
            }
            if (!isFlower)
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
            pikminDetect.instance.insertPikmin(this.gameObject, this.gameObject);
        }
    }
}
