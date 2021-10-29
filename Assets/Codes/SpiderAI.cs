using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAI : MonoBehaviour
{
    [SerializeField] float m_speed = 2.5f;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] int attackDamage = 20;

    Transform Player;


    private Animator animator;

    //private Animator pAnimator;
    private Rigidbody2D rb;
    public Transform attackPoint;
    private SpiderTakeDamage TKspider;
    public LayerMask EnemyLayers;
    private PlayerTakeDamage PlayerDied;

    // Start is called before the first frame update
    void Start()
    {
        PlayerDied = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTakeDamage>();
        TKspider = GetComponent<SpiderTakeDamage>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        //pAnimator = Player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        // Move
            Vector2 target = new Vector2(Player.position.x, rb.position.y);
            Vector2 NewPos = Vector2.MoveTowards(rb.position, target, Time.fixedDeltaTime * m_speed);
            rb.MovePosition(NewPos);
        

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
