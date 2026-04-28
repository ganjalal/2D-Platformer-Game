using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 moveDirection;
    float moveSpeed;

    public void Initialize(Vector3 direction,float speed)
    {
        moveDirection = direction.normalized;
        moveSpeed = speed;
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        Destroy(gameObject,10f);
    }

    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
