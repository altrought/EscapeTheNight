using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fairyAnimate : MonoBehaviour
{

    public Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim.Play("Idle");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            anim.Play("Attack1");
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.Play("Run");
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.Play("Run");
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.Play("Run");
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.Play("Run");
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.Play("Attack3");
        }

    }
}
