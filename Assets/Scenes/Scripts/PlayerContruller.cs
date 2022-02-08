using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerContruller : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }
    void Move()
    {

        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out RaycastHit hitinfo,1000))
            { 
                agent.SetDestination(hitinfo.point);
                animator.SetBool("isRun", true);
                agent.isStopped = false;

            }
        }
        if(Vector3.Distance(transform.position,agent.destination) <= agent.stoppingDistance)
        {
            animator.SetBool("isRun", false);
            agent.isStopped = true;
        }

    }
}
