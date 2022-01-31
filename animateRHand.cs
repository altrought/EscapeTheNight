using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateRHand : MonoBehaviour
{

    public Animator animator2;

    public bool animPlayed;

    // Start is called before the first frame update
    void Start()
    {
        animator2 = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !animPlayed)
        {
            
            animator2.SetTrigger("fww");

            animPlayed = true;

        }

        if (Input.GetKeyDown(KeyCode.Space) && !animPlayed)
        {

            animator2.SetTrigger("fww");

            animPlayed = true;

        }
        if (Input.GetKeyDown(KeyCode.A) && !animPlayed || Input.GetKeyDown(KeyCode.LeftArrow) && !animPlayed)
        {

            animator2.SetTrigger("fww");

            animPlayed = true;

        }
        if (animPlayed)
        {
           
            animator2.SetTrigger("bkk");

            animPlayed = false;

        }
    }
}
