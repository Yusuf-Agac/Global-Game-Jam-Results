using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderTakeDamage : MonoBehaviour
{
    public int maxHealth;
    //private Animator anim;
    public SpiderAI Func;
    private Rigidbody2D rb;
    private PolygonCollider2D coll;
    public Animator SpiderAnim;
    Vector3 diePos;


    private void Start()
    {
        maxHealth = 60;
        coll = GetComponent<PolygonCollider2D>();
        rb = GetComponent<Rigidbody2D>();
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
        diePos = transform.position;
        coll.enabled = false;
        rb.gravityScale = 0;
        rb.velocity = new Vector3(0, 0, 0);
        SpiderAnim.SetTrigger("Death");
        Func.enabled = false;
        transform.position = diePos;
    }
}
