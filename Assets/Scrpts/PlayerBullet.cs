using UnityEngine;

public class PlayerBullet : MonoBehaviour
{   
    public int damage = 1;
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other != null)
        {   
            if(other.tag == "Enemy")
            {
                other.GetComponent<EnemyHealth>().TakeDamage(damage);
                Debug.Log("damage");
                Destroy(gameObject);
            }
        }
    }

    
}
