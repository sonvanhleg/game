using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float enemyMoveSpeed = 1f;
    protected PLayer pLayer;
    [SerializeField] protected float maxHP = 50f;
    protected float currentHp;
    [SerializeField] private Image hpBar;
    [SerializeField] protected float enterDamage = 10f;
    [SerializeField] protected float stayDamage = 1f;

    
    protected virtual void Start()
    {
        pLayer = FindAnyObjectByType<PLayer>();
        currentHp = maxHP;
        UpdateHpBar();
    }

    protected virtual void Update()
    {
        MoveToPlayer();
    }

    protected void MoveToPlayer()
    {
        if (pLayer != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, pLayer.transform.position, enemyMoveSpeed * Time.deltaTime);
            FlipEnemy();
        }
    }
    protected void FlipEnemy()
    {
        if (pLayer != null)
        {
            transform.localScale = new Vector3(pLayer.transform.position.x < transform.position.x ? -1 : 1, 1, 1);
        }
    }
    public virtual void TakeDamage(float damage)
    {

        currentHp -=damage;
        currentHp = Mathf.Max(currentHp, 0);
        UpdateHpBar();
        if(currentHp <= 0)
        {
            Die();
        }
    }
    protected virtual void Die()
    {
        Destroy(gameObject);
    }
    protected void UpdateHpBar()
    {
        if(hpBar != null)
        {
            hpBar.fillAmount = currentHp / maxHP;
        }
    }
}
