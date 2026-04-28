using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyHealth : MonoBehaviour
{   
    public int health = 3;
    private int currentHealth;
    public Animator animator;
    public GameObject deathParticle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {   
        currentHealth = health;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {   
        currentHealth -= damage;
        // Debug.Log(currentHealth);
        if(currentHealth <= 0)
        {   
            Instantiate(deathParticle,transform.position,Quaternion.identity);
            Destroy(this.gameObject);
            return;
        }
        animator.SetTrigger("Damage");
       
        
    }

}
