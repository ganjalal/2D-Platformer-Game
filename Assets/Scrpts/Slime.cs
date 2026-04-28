using UnityEngine;

public class Slime : MonoBehaviour
{   public GameObject bulletPrefab;
    public float bulletSpeed = 2f;
    public LayerMask playerLayer;
    public float shootInterval = 2f;
    public float raydistance = 10f;
    public Transform firepoint;

    private float timer = 0f;
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        DetectAndFacePlayer();
        if(timer >= shootInterval)
         {
            Shoot();
            timer = 0f;
         }     
    }

    void Shoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(firepoint.position,-transform.right,raydistance,playerLayer);
        // Debug.DrawRay(firepoint.position,-transform.right * raydistance,Color.red,0.5f);

        if(hit.collider != null)
        {
            GameObject bullet = Instantiate(bulletPrefab,firepoint.position,transform.rotation);
            bullet.GetComponent<Bullet>().Initialize(-transform.right,bulletSpeed);
        }
    }

    void DetectAndFacePlayer()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, raydistance, playerLayer);
        if(playerCollider != null)
        {   
            float playerDirection = playerCollider.transform.position.x - transform.position.x;
            if (playerDirection > 0)
                transform.localRotation = Quaternion.Euler(0f, 180f, 0f);             // Face right: no rotation on Y
            else if (playerDirection < 0)
                transform.localRotation = Quaternion.Euler(0f, 0f, 0f);           // Face left: rotate 180 degrees on Y axis

        }
    }
}
