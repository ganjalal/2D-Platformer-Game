using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class health : MonoBehaviour
{   
    public GameObject[] hearts;
    private int life;
    public GameObject gameOverText;

    public Color damageColor = Color.white;
    public GameObject deathEffect;
    private bool dead = false;

    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        life = hearts.Length;
    }

    // Update is called once per frame
    void Update()
    {
     if(dead == true)
        {   Instantiate(deathEffect,transform.position,transform.rotation);
            gameOverText.SetActive(true);
            Destroy(this.gameObject);
        }
    }
    
    public void TakeDamage(int damage)
    {
        life -= damage;
        animator.SetTrigger("TakeDamage");
        Destroy(hearts[life].gameObject);
        if(life < 1)
            dead = true;
    }

    

    
}
