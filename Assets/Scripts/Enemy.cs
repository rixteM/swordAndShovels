using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int enemyHealth = 4;

    public float patroltime = 10f;
    public float aggrorange = 10f;
    public Transform[] waypoints;

    private int index;
    private float speed, agentSpeed;
    private Transform player;

    private Animator anim;
    private NavMeshAgent agent;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        if (agent != null)
        {
            agentSpeed = agent.speed;
        }

        player = GameObject.FindGameObjectWithTag("Player").transform;
        index = Random.Range(0, waypoints.Length);

        InvokeRepeating("Tick", 0f, 0.5f);

        if (waypoints.Length > 0)
        {
            InvokeRepeating("Patrol", 0, patroltime);
        }
    }

    void Patrol()
    {
        index = index == waypoints.Length - 1 ? 0 : index + 1;

        //if (index == waypoints.Length - 1)
        //    index = 0;
        //else
        //    index++;
    }

    void Tick()
    {
        agent.destination = waypoints[index].position;
        agent.speed = agentSpeed / 2;

        if (player != null && Vector3.Distance(transform.position, player.position) < aggrorange)
        {
            agent.destination = player.position;
            agent.speed = agentSpeed;
        }
    }
}
