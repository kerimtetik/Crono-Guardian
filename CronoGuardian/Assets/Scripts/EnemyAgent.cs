using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float detectionRange = 5f;
    public float attackRange = 1f; // Sald�r� menzili
    public int health = 3;
    public int damage = 1;
    public Transform attackPoint;
    public LayerMask playerLayer;

    private Transform player;
    private bool isChasing = false;
    private bool isAttacking = false;
    private Animator anim;
    private Rigidbody2D rb2d;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange && distanceToPlayer > attackRange)
        {
            isChasing = true;
            isAttacking = false;
        }
        else if (distanceToPlayer <= attackRange)
        {
            isChasing = false;
            isAttacking = true;
        }
        else
        {
            isChasing = false;
            isAttacking = false;
        }

        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (isAttacking)
        {
            Attack();
        }
    }

    void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb2d.velocity = new Vector2(direction.x * speed, rb2d.velocity.y);
        anim.SetBool("isRunning", true);

        if (direction.x > 0 && transform.localScale.x < 0)
        {
            Flip();
        }
        else if (direction.x < 0 && transform.localScale.x > 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        anim.SetBool("isDead", true);
        Destroy(gameObject, 1f);
    }

    void Attack()
    {
        anim.SetBool("isAttacking", true);
        //rb2d.velocity = Vector2.zero; // Sald�r� s�ras�nda hareketi durdur

        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        foreach (Collider2D player in hitPlayers)
        {
            //player.GetComponent<CharacterMove>().TakeDamage(damage);
        }
    }

    void AttackEnd()
    {
        anim.SetBool("isAttacking", false);
    }

}
