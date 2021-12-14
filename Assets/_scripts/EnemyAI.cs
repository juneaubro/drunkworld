using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    public float lookRadius = 10f;
    public Transform target;

    NavMeshAgent myAgent;
    public GameObject[] waypoints;

    public float damageDelay = 1f;
    private float damageTimer = 0f;


    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        PickWayPoint();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            myAgent.SetDestination(target.position);

            myAgent.speed = 4f;
            anim.SetBool("isFollowing", true);

            if (distance <= myAgent.stoppingDistance)
            {
                FaceTarget();
                anim.SetBool("isAttacking", true);
                
                damageTimer += Time.deltaTime;
                if (damageTimer > damageDelay)
                {
                    damageTimer -= damageDelay;

                    PlayerHealth player = target.GetComponent<PlayerHealth>();
                    if (player != null)
                        player.TakeDamage(10);
                }
                
            }
            else
            {
                damageTimer = 0;
                anim.SetBool("isAttacking", false);
            }
        }
        else
        {
            anim.SetBool("isFollowing", false);
        }
        
        if (myAgent.remainingDistance < 1f)
            PickWayPoint();
    }

    

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void PickWayPoint()
    {
        int randomWPnum;
        randomWPnum = Random.Range(0, waypoints.Length);

        myAgent.SetDestination(waypoints[randomWPnum].transform.position);
    }

    
}
