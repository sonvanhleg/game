using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    private Animator animator;
    private bool isGround;
    private Rigidbody2D m_rb;
    private GameManager gameManager;
    private AudioManager audioManager;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        m_rb = GetComponent<Rigidbody2D>();
        gameManager = FindFirstObjectByType<GameManager>();
        audioManager = FindFirstObjectByType<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsGameover() || gameManager.IsGameWin())
        {
            return;
        }
        HandleJump();
        UpdateAnimation();
    }
    private void FixedUpdate()
    {
        HandleMovement();
    }
    private void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        m_rb.velocity = new Vector2(moveInput * moveSpeed, m_rb.velocity.y);
        if(moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(moveInput > 0)
        {
            transform.localScale = Vector3.one;
        }
    }
    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGround)
        {
            audioManager.PlayJumpSound();
            m_rb.velocity = new Vector2(m_rb.velocity.x, jumpForce);
        }
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void UpdateAnimation()
    {
        bool isRunning = Mathf.Abs(m_rb.velocity.x) > 0.1f;
        bool isJumping = !isGround;
        animator.SetBool("Run", isRunning);
        animator.SetBool("Jump", isJumping);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            gameManager.AddScore(1);
            audioManager.PlayCoinSound();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Trap"))
        {
            gameManager.Gameover();
        }
        else if (collision.CompareTag("Enemy"))
        {
            gameManager.Gameover();
        }
        else if (collision.CompareTag("Key"))
        {
            gameManager.GameWin();
            Destroy(collision.gameObject);
        }
    }
}
