using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSteer : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public float followRange = 5f; // Distance at which the seal follows
    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float distance = Vector2.Distance(target.transform.position, transform.position);

        if (distance < followRange)
        {
            Vector2 direction = (target.transform.position - transform.position).normalized;
            body.linearVelocity = direction * speed;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject == target)
        {
            GetComponent<AudioSource>()?.Play();
        }
    }
}