using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    NavMeshAgent myAgent;
    public const int maxHealth = 30;
    public int currentHealth = maxHealth;

    public float timeToDestory = 10f;

    private Animator anim;

    private void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            myAgent.isStopped = true;
            gameObject.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
            anim.SetBool("isDead", true);
            anim.SetBool("isFollowing", false);
            anim.SetBool("isAttacking", false);

            Debug.Log("Enemy " + this.gameObject.GetInstanceID() + " is dead!");
            Destroy(this.gameObject, timeToDestory);
        }
    }

}
