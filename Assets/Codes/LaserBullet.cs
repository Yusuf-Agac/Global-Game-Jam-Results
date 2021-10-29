using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : MonoBehaviour
{
    public Rigidbody2D rb;

    private float t=0;
    private float startT;
    public float BulletSpeed=20f;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * BulletSpeed;
        startT = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        t = Time.time - startT;
        if (t > 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
