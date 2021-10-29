using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGround : MonoBehaviour
{
    [HideInInspector]
    public bool GroundColl=true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GroundColl = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GroundColl = false;
    }
}
