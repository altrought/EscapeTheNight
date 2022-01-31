using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMusic : MonoBehaviour
{


    public AudioClip bgClip;

    public bool soundplayed;

    // Start is called before the first frame update
    void Start()
    {
        soundplayed = false;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!soundplayed)
        {
            AudioSource.PlayClipAtPoint(bgClip, transform.position);
            soundplayed = true;
        }
    }
}
