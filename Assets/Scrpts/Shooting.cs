using UnityEngine;

public class Shooting : MonoBehaviour
{   
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public health h;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X) )
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(transform.localScale.x,0) * bulletSpeed;
        // Debug.Log();
        Destroy(bullet,0.8f);
    }
}
