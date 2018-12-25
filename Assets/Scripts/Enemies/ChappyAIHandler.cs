using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class ChappyAIHandler : MonoBehaviour {

    // Settables
    public float detectionRadius = 10f;
    public float extraRotationSpeed;
    Transform target;
    NavMeshAgent agent;

    // AI Turning isnt enough so we need more rotatiooononnnn
    void extraRotation()
    {
        Vector3 lookrotation = agent.steeringTarget - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookrotation), extraRotationSpeed * Time.deltaTime);
    }

    // Use this for initialization
    void Start ()
    {
        target = playerSingleton.instance.player.gameObject.transform;
        agent = GetComponent<NavMeshAgent>();
	}

    void FixedUpdate()
    {
        extraRotation();

        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= detectionRadius)
        {
            agent.SetDestination(target.position);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
