using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class playerDistance : MonoBehaviour
{
    private Transform t;
    private Transform player;

    public Animator animator;
    public Animation anim;

    private void Awake()
    {
        t = this.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Start()
    {

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        var dist = Vector3.Distance(t.position, player.position);

        //if (player)
        //    print(player.name + " is " + Distance().ToString() + " units from " + t.name);

        //else
        //    print("Player not found!");

        if (dist >= 3.5f) 
        {
            //animator.SetTrigger("Idle");
            anim.Play("Idle");
        }

        if (dist <= 3.5f && dist >= 2.3f )
        {
            //animator.SetTrigger("Idle");
            anim.Play("Run");
        }

        if (dist <= 2.3f)
        {
            //animator.SetTrigger("Idle");
            anim.Play("Attack1");

        }

        //if (animator.gameObject.activeSelf)
        //{
        //    animator.Play("Idle");
        //}
    }

    private float Distance()
    {
        return Vector3.Distance(t.position, player.position);
    }
}
