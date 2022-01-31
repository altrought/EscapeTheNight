using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    public Slider healthSlider;
    public float maxHealth;
    public static float currentHealth;

    private bool isCoroutineExecuting = false;

    public GameObject deathCanvas;

    public AudioClip deathClip;

    public bool soundplayed;

    public int startHealth;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startHealth;
        deathCanvas.SetActive(false);

        soundplayed = false;

    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = currentHealth;


        if (currentHealth <= 0)
        {
            deathCanvas.SetActive(true);
            if (!soundplayed)
            {
                AudioSource.PlayClipAtPoint(deathClip, transform.position);
                soundplayed = true;
            }
            StartCoroutine(ExampleCoroutine());

        }

    }

    void Reload()
    {

        Scene thisScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();

        UnityEngine.SceneManagement.SceneManager.LoadScene(thisScene.name);


    }

    IEnumerator ExampleCoroutine()
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(2);

        // Code to execute after the delay
        Reload();

        isCoroutineExecuting = false;
    }


    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ouch" && currentHealth >= 100) 
        {
            currentHealth -= 50;
        
        }
    }

}
