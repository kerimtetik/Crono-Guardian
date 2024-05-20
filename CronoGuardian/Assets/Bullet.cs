using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float bulletSpeed;
    public float endTime;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity= transform.right*bulletSpeed;
        Destroy(gameObject, endTime);
    }

   
    private void onTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            
            collision.GetComponent<Enemy>().TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
