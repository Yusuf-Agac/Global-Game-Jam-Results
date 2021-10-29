using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BatteryUP : MonoBehaviour
{
    public bool isTaked=false;
    public float startTime = 10000000000000;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            startTime = Time.time;
            isTaked = true;
            gameObject.SetActive(false);
        }
    }
}
