using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerraManager : MonoBehaviour
{
    [Header("Move")]
    private float horizontal;
    public float speed = 6f;
    public bool canMove = true;
    [SerializeField] private Rigidbody2D rb;

    [Header("Gravity")]
    public float gravityScale;

    [Header("Jump")]
    public float jumpingPower = 16f;
    private bool isFacingRight = true;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [Header("Fall")]
    public float maxFallSpeed;
    public float fallGravityMult;

    [Header("CoyoteTime")]
    public float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    [Header("JumpBuffering")]
    public float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerPrefs.GetInt("PlayerIsTerra") == 1)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            if (IsGrounded())
            {
                coyoteTimeCounter = coyoteTime;
            }

            else
            {
                coyoteTimeCounter -= Time.deltaTime;
            }

            if (Input.GetButtonDown("Jump"))
            {
                jumpBufferCounter = jumpBufferTime;
                //animator.SetBool("IsJumping", true);
            }

            else
            {
                jumpBufferCounter -= Time.deltaTime;
            }

            if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
            {
                //rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                float force = jumpingPower;
                if (rb.velocity.y < 0)
                    force -= rb.velocity.y;

                rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);

                jumpBufferCounter = 0f;

            }

            if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f || Input.GetKeyDown(KeyCode.UpArrow) && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

                coyoteTimeCounter = 0f;
            }

            if (rb.velocity.y < 0)
            {
                //Higher gravity if falling
                SetGravityScale(gravityScale * fallGravityMult);
                //Caps maximum fall speed, so when falling over large distances we don't accelerate to insanely high speeds
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -maxFallSpeed));
            }
        }
    }

    private void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("PlayerIsTerra") == 1)
        {
            Move();
        }
    }
    public void SetGravityScale(float scale)
    {
        rb.gravityScale = scale;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheck.GetComponent<CircleCollider2D>().radius, groundLayer);
    }

    void Move()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
