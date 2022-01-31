using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameMaster gm;

    public AudioSource audios;
    public AudioClip sound;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

        audios = GetComponent<AudioSource>();

        if (audios == null)
        {
            audios = this.GetComponent<AudioSource>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            audios.PlayOneShot(sound);
            gm.lastCheckpointPos = transform.position;
        
        }
    }
}
