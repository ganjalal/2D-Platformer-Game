using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int damage = 1;
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<health>().TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
