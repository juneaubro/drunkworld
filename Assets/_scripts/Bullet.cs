using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int maxDamageInflicted = 5;
    public float speed = 15f;

    public float bulletLife = 2.0f;

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        Destroy(this.gameObject, bulletLife);
    }


    private void OnTriggerEnter(Collider collision)
    {
        var hit = collision.gameObject;
        if (hit.tag == "Enemy")
        {
            var health = hit.GetComponent<EnemyHealth>();
            health.TakeDamage(maxDamageInflicted);
        }
        Destroy(this.gameObject);
    }
}
