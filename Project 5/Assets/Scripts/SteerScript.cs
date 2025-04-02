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

    private Rigidbody2D body;
    private Vector2 movementDirection;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        StartCoroutine(ChangeDirectionRoutine());
    }

    void FixedUpdate()
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

    void FollowPlayer()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        body.linearVelocity = direction * followSpeed;
    }

    void Wander()
    {
        body.linearVelocity = movementDirection * wanderSpeed;
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
