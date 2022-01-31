using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerPopUp : MonoBehaviour
{
    // Start is called before the first frame update

    public string popUp;
    public float counter;

    private bool isCoroutineExecuting = false;

    void Start()
    {
        counter = 0;
    }


    public void mouseVisible()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void mouseHidden()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && counter == 0)
        {
            PopUpInstructions pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpInstructions>();
            pop.popUP(popUp);
            StartCoroutine(ExampleCoroutine());
            AudioListener.volume = 0;

            counter = 1;
        }
    }

    IEnumerator ExampleCoroutine()
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(.6f);

        // Code to execute after the delay
        Time.timeScale = 0;

        isCoroutineExecuting = false;
    }
}
