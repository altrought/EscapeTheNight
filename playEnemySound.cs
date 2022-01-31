using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playEnemySound : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform t;
    private Transform player;
    public AudioSource audios;
    public AudioClip sound;
    private void Awake()
    {
        t = this.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Start()
    {
        audios = GetComponent<AudioSource>();

        if (audios == null)
        {
            audios = this.GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        var dist = Vector3.Distance(t.position, player.position);
        //Debug.Log(dist);
        if (dist >= 6.5f)
        {
            audios.volume = 0;
        }

        //if (dist <= 6.5f)
        //{
        //    audios.volume = 0.5f;
        //    audios.PlayOneShot(sound);

        //}
    }

    public void PlaySound() 
    {

        audios.volume = 0.5f;
        audios.PlayOneShot(sound);

    }
}
