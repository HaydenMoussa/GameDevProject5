using System.Collections;
using UnityEngine;

public class SteerScript : MonoBehaviour
{
    public GameObject player;
    public float followSpeed = 2f;
    public float wanderSpeed = 2f;
    public float followRange = 5f;
    public float stopRange = 1f; // Distance at which the seal stops moving
    public float changeDirectionInterval = 2f;
    private bool isInNest = false;
    private Collider2D nestCollider;

    private Rigidbody2D body;
    private Vector2 movementDirection;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        StartCoroutine(ChangeDirectionRoutine());
    }

    void FixedUpdate()
    {
        if (isInNest)
        {
            Wander(); // Only wander inside the nest
        }
        else
        {
            float distance = Vector2.Distance(player.transform.position, transform.position);

            if (distance < stopRange)
            {
                StopMoving();
            }
            else if (distance < followRange)
            {
                FollowPlayer();
            }
            else
            {
                Wander();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Nest")) 
        {
            isInNest = true;
            nestCollider = other;
        }
    }

    void FollowPlayer()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        body.linearVelocity = direction * followSpeed;
    }

    void Wander()
    {
        if (isInNest && nestCollider != null)
        {
            Vector2 newPosition = (Vector2)transform.position + movementDirection * wanderSpeed * Time.fixedDeltaTime;
            
            // new position is within the nest bounds
            Bounds bounds = nestCollider.bounds;
            newPosition.x = Mathf.Clamp(newPosition.x, bounds.min.x, bounds.max.x);
            newPosition.y = Mathf.Clamp(newPosition.y, bounds.min.y, bounds.max.y);

            body.MovePosition(newPosition);
        }
        else
        {
            body.linearVelocity = movementDirection * wanderSpeed;
        }
    }

    void StopMoving()
    {
        body.linearVelocity = Vector2.zero;
    }

    IEnumerator ChangeDirectionRoutine()
    {
        while (true)
        {
            movementDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            yield return new WaitForSeconds(changeDirectionInterval);
        }
    }
}
