using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    bool alreadyAttacked;
    public GameObject projectile;
    public float timeBetweenAttacks;

    public AudioClip shotClip;
    public bool soundplayed;


    //public Animator animator;
    //public bool animPlayed;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        //animPlayed = false;

        soundplayed = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attacking();
            //animator.SetTrigger("fw");

           // animPlayed = true;

        }

        //if (animPlayed) 
        //{
        //    animator.SetTrigger("bk");

        //    animPlayed = false;

        //}
    }


    //void OnMouseUp()
    //{
    //    animator.SetTrigger("bk");

    //}

    void Attacking()
    {


        if (!alreadyAttacked)
        {
            //attack code here

            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 5f, ForceMode.Impulse);

            //

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);

            if (!soundplayed)
            {
                AudioSource.PlayClipAtPoint(shotClip, transform.position);
                //soundplayed = true;
            }
        }



    }

    private void ResetAttack()
    {

        alreadyAttacked = false;
    }
}
