using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class DwarfRedBulborb : MonoBehaviour {

    // Settables
    public float detectionRadius = 10f;
    Transform target;
    NavMeshAgent agent;

    // Privates
	private CapsuleCollider collider_range; // this is the enemy's actual range.
    private bool isInRange = false;
	// Use this for initialization
	void Start ()
    {
        target = Player.instance.player.gameObject.transform;
        agent = GetComponent<NavMeshAgent>();
	}

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= detectionRadius)
        {
            agent.SetDestination(target.position);
        }
    }

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player" || other.tag == "Pikmin") {

            isInRange = true;
		}
	}

    void OnTriggerExit (Collider other)
    {
        if (other.tag == "Player" || other.tag == "Pikmin")
        {

            isInRange = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
