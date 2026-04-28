using UnityEngine;

public class Patrol : MonoBehaviour
{   
    public float timeToInvert = 2f;
    public float moveSpeed = 4f;
    private float cooldown = 0f;

    // Update is called once per frame
    void Update()
    {   
        transform.position += transform.right * moveSpeed * Time.deltaTime;

        cooldown -= Time.deltaTime; 
        if(cooldown <= 0f)
            {
                transform.Rotate(0f,180f,0f);
                cooldown = timeToInvert;
            }
    }

}
