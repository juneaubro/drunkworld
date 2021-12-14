using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    public float lookRadius = 10f;
    public GameObject target;

    NavMeshAgent myAgent;
    public GameObject[] waypoints;

    public float damageDelay = 2f;
    private float damageTimer = 0f;

    public HealthBarScreenSpaceController playerHealthBar;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        playerHealthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBarScreenSpaceController>();
        PickWayPoint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance <= lookRadius)
        {
            myAgent.SetDestination(target.transform.position);

            anim.SetBool("isFollowing", true);
            myAgent.speed = 4f;

            if (distance <= myAgent.stoppingDistance)
            {
                FaceTarget();
                anim.SetBool("isAttacking", true);
                
                damageTimer += Time.deltaTime;
                if (damageTimer > damageDelay)
                {
                    damageTimer -= damageDelay;
                    AttackPlayer();
                    //InvokeRepeating("AttackPlayer", 0.95f, 0.75f);
                }
                
            }
            else
            {
                damageTimer = 0;
                anim.SetBool("isAttacking", false);
                //CancelInvoke();
            }
        }
        else
        {
            anim.SetBool("isFollowing", false);
            myAgent.speed = 0.5f;
            PickWayPoint();
        }
        
        
    }

    void AttackPlayer()
    {
        if (playerHealthBar != null)
            playerHealthBar.TakeDamage(10);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void PickWayPoint()
    {
        if (myAgent.remainingDistance < 1f)
        {
            int randomWPnum;
            randomWPnum = Random.Range(0, waypoints.Length);

            myAgent.SetDestination(waypoints[randomWPnum].transform.position);
        }
        else
        {
            return;
        }
    }

    
}
