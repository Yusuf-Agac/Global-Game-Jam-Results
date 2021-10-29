using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAI1 : MonoBehaviour
{
    [SerializeField] float m_speed = 2.5f;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] int attackDamage = 12;

    Transform Player;


    private Animator animator;

    //private Animator pAnimator;
    private Rigidbody2D rb;
    public Transform attackPoint;
    public Transform UP;
    public Transform DOWN;
    public Transform FRONT;
    private SpiderTakeDamage1 TKspider;
    public LayerMask EnemyLayers;
    public LayerMask isGroundLayer;
    private PlayerTakeDamage PlayerDied;
    private bool isUp;
    private bool isDown;
    private bool isFront;
    public float radiusOfAI;
    public float AIamount;
    // Start is called before the first frame update
    void Start()
    {
        PlayerDied = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTakeDamage>();
        TKspider = GetComponent<SpiderTakeDamage1>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        //pAnimator = Player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Bee Up Down AI
        isUp=Physics2D.OverlapCircle(UP.position, radiusOfAI, isGroundLayer); 
        isDown = Physics2D.OverlapCircle(DOWN.position, radiusOfAI, isGroundLayer);
        isFront = Physics2D.OverlapCircle(FRONT.position, radiusOfAI*1.5f, isGroundLayer);
        if (isUp && isDown && !isFront)
        {
            // Move
            Vector2 target = new Vector2(Player.position.x, Player.position.y);
            Vector2 NewPos = Vector2.MoveTowards(rb.position, target, Time.fixedDeltaTime * m_speed);
            rb.MovePosition(NewPos);
        }
        else
        {
            if (isFront)
            {
                rb.velocity = new Vector2(rb.velocity.x, -AIamount*1.5f);
            }
            if (isUp)
            {
                rb.velocity = new Vector2(rb.velocity.x, -AIamount);
            }
            else if (isDown)
            {
                rb.velocity = new Vector2(rb.velocity.x, AIamount);
            }
            else
            {
                // Move
                Vector2 target = new Vector2(Player.position.x, Player.position.y);
                Vector2 NewPos = Vector2.MoveTowards(rb.position, target, Time.fixedDeltaTime * m_speed);
                rb.MovePosition(NewPos);
            }
        }
        // X direction
        float inputX = Player.position.x - transform.position.x;

        // Swap direction of sprite depending on walk direction
        if (inputX > 0)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (inputX < 0)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        if (PlayerDied.isDied)
        {
            Win();
        }
    }

    public void Attacking()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, EnemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<PlayerTakeDamage>().Hurting(attackDamage);
        }
    }
    private void Win()
    {
        animator.SetTrigger("EnemyDied");
        enabled = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Laser"))
        {
            TKspider.Hurting(20);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
