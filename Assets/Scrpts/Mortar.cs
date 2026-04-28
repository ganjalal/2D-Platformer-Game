using UnityEngine;

public class Mortar : MonoBehaviour
{   
    public Transform[] patrolPoints;
    public float patrolSpeed = 2f;
    private int patrolIndex = 0;

    public float detectionRange = 8f;
    public Transform player;

    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireCooldown = 2f;
    public float projectileSpeed = 7f;
    private float fireTimer = 0f;

    void Update()
    {
        if (PlayerInRange())
        {
            fireTimer += Time.deltaTime;
            if (fireTimer >= fireCooldown)
            {
                ShootAtPlayer();
                fireTimer = 0f;
            }
        }
        else
        {
            Patrol();
        }
    }

    void ShootAtPlayer()
    {
        Vector2 target = player.position;
        Vector2 start = firePoint.position;
        Vector2 direction = target - start;

    // Calculate the firing angle (45 degrees for a high arc, adjust as needed)
        float angle = 45f * Mathf.Deg2Rad;
        float distance = direction.magnitude;
        float gravity = Mathf.Abs(Physics2D.gravity.y);

    // Calculate the velocity needed to hit the target at the given angle
        float velocity = Mathf.Sqrt(distance * gravity / Mathf.Sin(2 * angle));

    // Calculate velocity components
        Vector2 velocityVector = new Vector2(
        velocity * Mathf.Cos(angle) * Mathf.Sign(direction.x),
        velocity * Mathf.Sin(angle)
    );

    // Instantiate and launch the projectile
        GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        proj.GetComponent<Rigidbody2D>().linearVelocity = velocityVector;
    }

    bool PlayerInRange()
        {
            return Vector2.Distance(transform.position, player.position) <= detectionRange;
        }

    void Patrol()
        {
            if (patrolPoints.Length == 0) return;
            Transform target = patrolPoints[patrolIndex];
            transform.position = Vector2.MoveTowards(transform.position, target.position, patrolSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, target.position) < 0.1f)
            patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
        }
}
