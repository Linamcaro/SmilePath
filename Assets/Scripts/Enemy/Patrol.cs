using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private Animator animator;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private int randomPoint = 0;

    private teleport teleport;
    private Transform player;
    public float patrolSpeed = 1.2f;
    public float detectionDistance = 5f;
    public float chaseSpeed = 5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        teleport = GetComponent<teleport>();

        teleport.StopPatrol += patrol_OnStopPatrol;

        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Disabling auto-braking allows for continuous movement
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < detectionDistance)
        {
            animator.SetBool("isWalking",false);
            animator.SetBool("isTeleporting",false);
            animator.SetBool("isRunning",true);
            ChasePlayer();
        }
        else if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {     // Choose the next destination point when the agent gets
              // close to the current one.

            animator.SetBool("isRunning",false);
            animator.SetBool("isTeleporting",false);
            animator.SetBool("isWalking",true);
            GotoNextPoint();
        }
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        int previousDestPoint = 1000;

        randomPoint = destPoint = Random.Range(0, points.Length);

        if (randomPoint != previousDestPoint)
        {
            previousDestPoint = destPoint;
            destPoint = randomPoint;
        }

        agent.speed = patrolSpeed;
        // Set the agent to go to the currently selected destination.
        SetDestination(points[destPoint].position);
    }

    private void ChasePlayer()
    {
        agent.speed = chaseSpeed;
        SetDestination(player.position);

    }

    private void patrol_OnStopPatrol(object sender, System.EventArgs e)
    {
        agent.speed = 0;
    }

    private void SetDestination(Vector3 target)
    {
        agent.destination = target;
    }
}
