using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public AudioSource source;
    public GameObject LaserPrefab;
    private Transform AttackPoint;
    public Animator Panim;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        AttackPoint = GameObject.FindGameObjectWithTag("Point").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            Panim.SetTrigger("Attacking");
            source.Play();
        }
    }
    void Shoot()
    {
        Instantiate(LaserPrefab, AttackPoint.position, AttackPoint.rotation);
    }
}
