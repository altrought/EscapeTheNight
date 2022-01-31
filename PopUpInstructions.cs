using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PopUpInstructions : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator animator;
    public TMP_Text popUpText;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {

            //popUpBox.SetActive(false);
            animator.SetTrigger("close");
            Time.timeScale = 1;
            AudioListener.volume = 1;

        }
    }
    public void popUP(string text) 
    {
        popUpBox.SetActive(true);
        popUpText.text = text;

        animator.SetTrigger("pop");
        
    }


}
