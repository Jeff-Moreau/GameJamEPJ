using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthAndDamage : MonoBehaviour
{
    public float maxHealth;
    public float health;
    private bool invincible = false;
    public float invincibility;
    public float invincibilityDuration;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        invincibility = float.PositiveInfinity;
    }

    private void Update()
    {
        if (invincibility < invincibilityDuration)
        {
            invincibility += Time.deltaTime;
            invincible = true;
        }
        else
        {
            invincible = false;
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (!invincible)
            {
                TakeDamage(10);
                if (health > 0)
                {
                    Destroy(collision.gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                Destroy(collision.gameObject);
            }
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

        if (other.gameObject.CompareTag("Shield"))
        {
            invincibility = 0f;
            
            Destroy(other.gameObject);
        }
    }


    

}
