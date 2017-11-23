using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveByNavMesh : MonoBehaviour {

    private NavMeshAgent navMesh;
    //public Transform targetObj;
    private Animator animator;

    float minDis = 1;
    // Use this for initialization
    void Start () {
        navMesh = this.GetComponent<NavMeshAgent>();
        animator = this.transform.GetComponent<Animator>();
        navMesh.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (navMesh.enabled)
        {
            if (navMesh.remainingDistance < minDis && navMesh.remainingDistance != 0)
            {
                navMesh.isStopped = true;
                navMesh.enabled = false;
                animator.SetBool("Run", false);
            }
        
        }

	}


    public void setDestination(Vector3 targetPos)
    {
        navMesh.enabled = true;
        navMesh.isStopped = false;
        navMesh.stoppingDistance = minDis;
        navMesh.SetDestination(targetPos);
    }

}
