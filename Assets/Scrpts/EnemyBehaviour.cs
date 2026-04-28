using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{   
    public float playerDetectionRadious = 5f;
    public LayerMask playerLayer;
    public Transform firePoint;
    private Collider2D player;
    
    public GameObject bulletPrefab;
    public float bulletSpeed = 5f;
    public float fireRate = 1f;
    private float fireCoolDown = 0f;
    public float rotationSpeed = 50f;

    // Update is called once per frame
    void Update()
    {
        player = Physics2D.OverlapCircle(transform.position,playerDetectionRadious,playerLayer);
        if(player)
        {   
            Vector3 direction = (player.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
            Quaternion targetRotation =Quaternion.Euler(0f,0f,angle - 90f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,targetRotation,rotationSpeed*Time.deltaTime);

            fireCoolDown -= Time.deltaTime;
            if(fireCoolDown <= 0f)
                {
                    ShootAtPlayer();
                    fireCoolDown = fireRate;
                }
        }
    }

    void ShootAtPlayer()
    {   Quaternion bulletRotation = Quaternion.Euler(firePoint.eulerAngles.x,firePoint.eulerAngles.y,firePoint.eulerAngles.z + 90f);
        GameObject bullet = Instantiate(bulletPrefab,firePoint.position,bulletRotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = firePoint.up * bulletSpeed;
        Destroy(bullet,10f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,playerDetectionRadious);
    }
}
