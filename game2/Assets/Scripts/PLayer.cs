using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PLayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D m_rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    [SerializeField] private float maxHp = 100f;
    private float currentHp;
    [SerializeField] private Image hpBar;
    // Start is called before the first frame update
    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
       
    }
    void Start()
    {
        currentHp = maxHp;
        UpdateHpBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        m_rb.velocity = playerInput.normalized * moveSpeed;
        if(playerInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }else if (playerInput.x > 0)
        {
            spriteRenderer.flipX= false;
        }
        if(playerInput != Vector2.zero)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }
    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        currentHp = Mathf.Max(currentHp, 0);
        UpdateHpBar();
        if(currentHp <= 0)
        {
            Die();
        }
    }
    public void Heal(float healValue)
    {
        if(currentHp < maxHp)
        {
            currentHp += healValue;
            currentHp = Mathf.Min(currentHp, maxHp);
            UpdateHpBar();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    private void UpdateHpBar()
    {
        if(hpBar != null)
        {
            hpBar.fillAmount = currentHp / maxHp;
        }
    }
}
