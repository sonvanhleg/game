using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce = 15f;
    private Rigidbody2D rb;
    private bool isGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    private Animator anim;
    [SerializeField] private BoxCollider2D normalCollider;
    [SerializeField] private CapsuleCollider2D duckCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        normalCollider.enabled = true;
        duckCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGround = CheckIsGrounded();
        HandleJump();
        HandleDuck();
        HandleSoundEffect();
    }
    private bool CheckIsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
    private void HandleJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
    private void HandleDuck()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow) )
        {
            normalCollider.enabled = false;
            duckCollider.enabled = true;
            anim.SetBool("IsDuck", true);
        }
        else if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            normalCollider.enabled = true;
            duckCollider.enabled = false;
            anim.SetBool("IsDuck", false);
        }
    }
    private void HandleSoundEffect()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            AudioManager.instance.PlayJumClip();
        }
        if(isGround && !AudioManager.instance.HasPlayEffectSound())
        {
            AudioManager.instance.PlayTapClip();
            AudioManager.instance.SetHasPlayEffectSound(true);
        }
        else
        {
            AudioManager.instance.SetHasPlayEffectSound(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            AudioManager.instance.PlayHurtClip();
        }
    }
}
