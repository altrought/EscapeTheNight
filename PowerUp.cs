using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update

    public float healing;
    GameObject obj;
    GameObject grab;
    public AudioSource audios;
    public AudioClip sound;
    private bool isCoroutineExecuting = false;

    public GameObject finish;

    void Start()
    {
        finish.SetActive(false);
        obj = GameObject.Find("Shooting");
        obj.SetActive(false);

        grab = GameObject.Find("GunPosition");
        grab.SetActive(false);


        audios = GetComponent<AudioSource>();

        if (audios == null)
        {
            audios = this.GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Heal()
    {

        Health.currentHealth += healing;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Health")
        {
           // audios.volume = 0.5f;
            audios.PlayOneShot(sound);
            Heal();
            Object.Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "canAttack")
        {
           // audios.volume = 0.5f;
            audios.PlayOneShot(sound);
            //var obj = GameObject.Find("Shooting");
            obj.SetActive(true);
            Object.Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Grabber")
        {
           // audios.volume = 0.5f;
            audios.PlayOneShot(sound);

            grab.SetActive(true);
            Object.Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Portal")
        {
            finish.SetActive(true);
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

        yield return new WaitForSeconds(5);

        // Code to execute after the delay
        Reload();

        isCoroutineExecuting = false;
    }
}
