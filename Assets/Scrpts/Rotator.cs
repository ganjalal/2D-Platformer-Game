using UnityEngine;

public class Rotator : MonoBehaviour
{   
    public float rotationSpeed = 100f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float shootInterval = 2f;


    private float timer = 0f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f,0f,rotationSpeed*Time.deltaTime);
        
        timer += Time.deltaTime;
        if(timer >= shootInterval)
         {
            ShootInFourDirections();
            timer = 0f;
         } 
    }

    void ShootInFourDirections()
    {
        Vector3[] directions = {transform.up,transform.right,-transform.up,-transform.right};
        foreach(Vector3 dir in directions)
            {
                GameObject bullet = Instantiate(bulletPrefab,transform.position,Quaternion.identity);
                bullet.GetComponent<Bullet>().Initialize(dir,bulletSpeed);
                Destroy(bullet,5f);
            }
    }
}
