using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        
    }


    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 2 * Time.fixedDeltaTime);
    }

    //
}
