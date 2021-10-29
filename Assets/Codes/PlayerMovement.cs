using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Vector3 velocity;
    Vector3 remPos;

    private Animator animator;
    private Rigidbody2D rb;
    private GameObject AttackPoint;
    public BatteryUP BatteryInfo;
    private PlayerTakeDamage TDfunc;
    private Transform isGroundTra;

    private float collDamageTimer1;
    private float collDamageTimer2=0;
    public float speed;
    public float ladderSpeed;
    public float JumpForce;
    public static float BatteryLevel=0;
    private bool isGround;
    public float isGroundRadius;
    public LayerMask isGroundLayer;
    public LayerMask LadderLayer;
    private bool isBatteryTaked = false;

    // Start is called before the first frame update
    void Start()
    {
        TDfunc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTakeDamage>();
        BatteryInfo = GameObject.FindGameObjectWithTag("Battery").GetComponent<BatteryUP>();
        remPos = transform.position;
        isGroundTra = GameObject.FindGameObjectWithTag("Ground").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        AttackPoint = GameObject.FindGameObjectWithTag("Point");

    }
    private void FixedUpdate()
    {


        float inputX = Input.GetAxis("Horizontal");



        // Move
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0);
        transform.position += velocity * speed * Time.deltaTime;


        //Ladder Moving
        RaycastHit2D LadderInfo = Physics2D.Raycast(transform.position, Vector2.up, 0.35f, LadderLayer);
        if (LadderInfo.collider != null)
        {
            if (Input.GetKey("w")&&LadderInfo.collider)
            {
                rb.velocity = new Vector2(rb.velocity.x, ladderSpeed * Input.GetAxis("Vertical"));
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D LadderInfo = Physics2D.Raycast(transform.position, Vector2.up, 0.35f, LadderLayer);
        // -- Handle input and movement --
        float inputX = Input.GetAxis("Horizontal");
        isGround = Physics2D.OverlapCircle(isGroundTra.position, isGroundRadius, isGroundLayer);

        //Jumping
        if (Input.GetKeyDown("w") && isGround)
        {
            Debug.Log("You Did Jump");
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }

        // Swap direction of sprite depending on walk direction
        if (inputX > 0)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            AttackPoint.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (inputX < 0)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            AttackPoint.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        rb.gravityScale = 1;

        //Battery up
        if(BatteryInfo.isTaked && !isBatteryTaked)
        {
            isBatteryTaked = true;
            BatteryLevel += 1;
        }
        if (inputX != 0)
        {
            animator.SetBool("Runing", true);
        }
        if (inputX == 0)
        {
            animator.SetBool("Runing", false);
        }
        if(TDfunc.isDied)
            Cursor.visible = true;
    }
    public void NextMenu()
    {
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(isGroundTra.position, isGroundRadius);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collDamageTimer1 = Time.time - collDamageTimer2;
        if (collision.collider.tag.Equals("Enemy")&&collDamageTimer1>1)
        {
            collDamageTimer2 = Time.time;
            TDfunc.Hurting(20);
        }
    }
}
