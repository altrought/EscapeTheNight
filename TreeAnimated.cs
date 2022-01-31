using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAnimated : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform t;
    private Transform player;

    public Animator animator;

    public Enemy other;

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
        //Debug.Log(dist);

        if (dist >= 4.9f)
        {
            //animator.SetTrigger("Idle");
            animator.SetBool("isIdle", true);
        }

        if (dist <= 4.8f)
        {
            //animator.SetTrigger("Idle");
            animator.SetBool("isWalking", true);
        }

        //if(other.currentHealth <= 0) 
        //{
        //    animator.SetBool("isDead", true);

        //}

        if (other.tookDamage) 
        {
            animator.SetBool("isHit", true);
        }

        if (!other.tookDamage)
        {
            animator.SetBool("isHit", false);
        }
    }
    public void AttackAnim() 
    {
        animator.SetBool("isAttacking", true);
    
    }

    public void NotAttacking() 
    {
        animator.SetBool("isAttacking", false);

    }

    public void isDying() 
    {
        animator.SetBool("isDead", true);

    }
}
