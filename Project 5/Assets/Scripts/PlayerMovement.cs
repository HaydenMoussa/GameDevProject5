using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rigidbody2D;
    private Animator animator;
    float horizontal;
    float vertical;
    public bool wonder = true;

    public float runSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetFloat("Speed", Mathf.Abs(horizontal) + Mathf.Abs(vertical));
    }

    void FixedUpdate()
    {
        rigidbody2D.linearVelocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}