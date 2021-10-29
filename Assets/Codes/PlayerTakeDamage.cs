using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerTakeDamage : MonoBehaviour
{
    public int maxHealth;
    public bool isDied = false;
    private float startTime=10000000000000;
    private float T;
    //private Animator anim;
    public SpiderAI Func;
    public PlayerMovement PlayerM;
    private Rigidbody2D rb;
    private CapsuleCollider2D coll;
    private Animator animator;
    Vector3 diePos;


    private void Start()
    {
        animator = GetComponent<Animator>();
        maxHealth = 250;
        coll = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        T = Time.time - startTime;
        if (T > 2)
        {
            SceneManager.LoadScene(0);
        }
    }
    public void Hurting(int Damage)
    {
        maxHealth -= Damage;
        //anim.SetTrigger("Hurt");
        if (maxHealth <= 0)
        {
            Cursor.visible = true;
            startTime = Time.time;
            animator.SetTrigger("Death");
            
            diePos = transform.position;
            coll.enabled = false;
            rb.gravityScale = 0;
            rb.velocity = new Vector3(0, 0, 0);
            Func.enabled = false;
            PlayerM.enabled = false;
            transform.position = diePos;
            isDied = true;
        }
        
        
    }
}
