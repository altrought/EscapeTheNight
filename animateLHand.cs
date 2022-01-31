using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateLHand : MonoBehaviour
{
    public Animator animator;
    public bool animPlayed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !animPlayed)
        {
       
            animator.SetTrigger("fw");

            animPlayed = true;

        }

        if (Input.GetKeyDown(KeyCode.Space) && !animPlayed)
        {

            animator.SetTrigger("fw");

            animPlayed = true;

        }
        if (Input.GetKeyDown(KeyCode.D) && !animPlayed || Input.GetKeyDown(KeyCode.RightArrow) && !animPlayed)
        {

            animator.SetTrigger("fw");

            animPlayed = true;

        }

        if (animPlayed)
        {
            animator.SetTrigger("bk");

            animPlayed = false;

        }
    }
}
