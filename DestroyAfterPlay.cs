using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterPlay : MonoBehaviour
{

    private bool isCoroutineExecuting = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ColorCoroutine());

    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator ColorCoroutine()
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(16);

        // Code to execute after the delay
        //TakeDamage();

        Destroy(this.gameObject);

        isCoroutineExecuting = false;
    }
}
