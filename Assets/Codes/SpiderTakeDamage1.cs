using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderTakeDamage1 : MonoBehaviour
{
    public int maxHealth;
    //private Animator anim;
    public SpiderAI1 Func;
    private Rigidbody2D rb;
    private PolygonCollider2D coll;
    public Animator SpiderAnim;
    private float startTime=100000000000000;
    private float T;
    Vector3 diePos;


    private void Start()
    {
        maxHealth = 60;
        coll = GetComponent<PolygonCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        T = Time.time - startTime;
        if (T > 2)
        {
            gameObject.SetActive(false);
        }
    }
    public void Hurting(int Damage)
    {
        if(maxHealth > 0)
        {
            maxHealth -= Damage;
            //anim.SetTrigger("Hurt");
            if (maxHealth <= 0)
            {
                Die();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Laser"))
        {
            Hurting(20);
        }
    }
    void Die()
    {
        startTime = Time.time;
        diePos = transform.position;
        coll.enabled = false;
        Func.enabled = false;
        rb.velocity = new Vector3(0, 0, 0);
        SpiderAnim.SetTrigger("Death");
        rb.gravityScale = 0.5f;
        transform.position = diePos;
    }
}
