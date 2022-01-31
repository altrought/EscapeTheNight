using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectPlayer : MonoBehaviour
{

    private Transform t;
    private Transform player;

    private bool isCoroutineExecuting = false;

    public Animator animator;
    public Animation anim;

    public float dist;

    private void Awake()
    {
        t = this.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(t.position, player.position);
        //Debug.Log("dist:" + dist);

    }


    IEnumerator ExampleCoroutine()
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(1.5f);

        // Code to execute after the delay
        Disappear();


        isCoroutineExecuting = false;
    }

    void OnCollisionEnter(Collision Other)
    {

        StartCoroutine(ExampleCoroutine());
        anim.Play("fadingPlatform");

    }

    void Disappear() 
    {
        Destroy(this.gameObject);
        if (dist <= 3.6f)
        {
            //animator.SetTrigger("Idle");
            //anim.Play("fadingPlatform");
        }
        else 
        {
            //anim.Play("resetPlatform");


        }
        //if (dist >= 2.6f)
        //{
        //    //animator.SetTrigger("Idle");
        //    anim.Play("resetPlatform");
        //}
    }
}
