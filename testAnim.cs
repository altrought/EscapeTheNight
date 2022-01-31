using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAnim : MonoBehaviour
{

    public Animator animator;
    int isWalkingHash;
    int isJumpingHash;
    int isAttackingHash;

    public AudioSource audios;
    public AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {

        audios = GetComponent<AudioSource>();

        if (audios == null)
        {
            audios = this.GetComponent<AudioSource>();
        }

        animator = GetComponent<Animator>();

        //animator.SetTrigger("idle");

        isWalkingHash = Animator.StringToHash("isWalking");
        isJumpingHash = Animator.StringToHash("isJumping");
        isAttackingHash = Animator.StringToHash("isAttacking");

        //Health other;
    }

    // Update is called once per frame
    void Update()
    {
        bool isJumping = animator.GetBool(isJumpingHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isAttacking = animator.GetBool(isAttackingHash);

        bool forward = Input.GetKey("w");
        bool back = Input.GetKey("s");
        bool left = Input.GetKey("a");
        bool right = Input.GetKey("d");

        bool jump = Input.GetKey("space");
        bool attack = Input.GetKey(KeyCode.Mouse0);


        if(!isWalking && forward) {animator.SetBool(isWalkingHash, true);}
        if (isWalking && !forward) {animator.SetBool(isWalkingHash, false);}
        if (!isWalking && back) { animator.SetBool(isWalkingHash, true); }
        if (isWalking && !back) { animator.SetBool(isWalkingHash, false); }
        if (!isWalking && left) { animator.SetBool(isWalkingHash, true); }
        if (isWalking && !left) { animator.SetBool(isWalkingHash, false); }
        if (!isWalking && right) { animator.SetBool(isWalkingHash, true); }
        if (isWalking && !right) { animator.SetBool(isWalkingHash, false); }

        if (!isJumping && jump) { animator.SetBool(isJumpingHash, true); }
        if (isJumping && !jump) { animator.SetBool(isJumpingHash, false); }

        if (!isAttacking && attack) { animator.SetBool(isAttackingHash, true); audios.volume = 0.5f;
            audios.PlayOneShot(sound);
         }
        if (isAttacking && !attack) { animator.SetBool(isAttackingHash, false); }

       if(Health.currentHealth <= 0) 
        {
            animator.SetBool("isDying", true);
        
        }
    }   
}
