using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    Transform tr_Player;
    float f_RotSpeed = 3.0f, f_MoveSpeed = 3.0f;
    public Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

        tr_Player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        // animator.SetTrigger("moving");
        /* Look at Player*/
       // anim.SetInteger("battle", 2);
       // anim.SetInteger("moving", 3);//crawl

        anim.SetInteger("battle", 0);
        anim.SetInteger("moving", 1);//walk

        transform.rotation = Quaternion.Slerp(transform.rotation
                                              , Quaternion.LookRotation(tr_Player.position - transform.position)
                                              , f_RotSpeed * Time.deltaTime);

        /* Move at Player*/
        //transform.position += transform.forward * f_MoveSpeed * Time.deltaTime;
    }
}
