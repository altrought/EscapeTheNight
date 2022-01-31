using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePlayer : MonoBehaviour
{
    private Transform t;
    private Transform player;

    Damage other;
    // Start is called before the first frame update
    private bool isCoroutineExecuting = false;

    private void Awake()
    {
        t = this.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Start()
    {
        other = GameObject.FindGameObjectWithTag("Player").GetComponent<Damage>();
    }

    // Update is called once per frame
    void Update()
    {
        var dist = Vector3.Distance(t.position, player.position);


        Debug.Log(dist);

        //if(dist <= 3) 
        //{
        //    other.TakeDamage();
        //    Destroy(this);
        
        //}
    }
    IEnumerator ExampleCoroutine()
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(0.2f);

        // Code to execute after the delay
        Destroy(this.gameObject);


        isCoroutineExecuting = false;
    }
    void OnCollisionEnter(Collision Other)
    {
        
            StartCoroutine(ExampleCoroutine());

    }

}
