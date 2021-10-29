using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isLadder : MonoBehaviour
{
    private PlayerMovement Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

}
