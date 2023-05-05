using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthAndDamage : MonoBehaviour
{
    public float maxHealth;
    public float health;
    
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            TakeDamage(10);
        }
    }

    public void healing(float heal)
    {
        health += heal;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Orb"))
        {
            healing(10);
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }


}
