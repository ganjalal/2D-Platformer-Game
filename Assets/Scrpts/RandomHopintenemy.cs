using UnityEngine;

public class Hopper : MonoBehaviour
{
    public float hopeForce = 5f;
    public float hopeInterval = 2f;

    private Rigidbody2D rb;
    private float nextHopeTime = 0f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nextHopeTime = Time.time + hopeInterval;
    }

    void Update()
    {
        if(Time.time >= nextHopeTime)
        {
            HopeInRandomDirection();
            nextHopeTime = Time.time + hopeInterval;
        }
    }

    void HopeInRandomDirection()
    {
        Vector2 randomDir = new Vector2(Random.Range(-1f,1f),Random.Range(0.5f,1f)).normalized;
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(randomDir * hopeForce,ForceMode2D.Impulse); 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Optionally, hop again immediately if you hit a wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            HopeInRandomDirection();
            nextHopeTime = Time.time + hopeInterval;
        }
    }
}
