using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurTheCamera : MonoBehaviour
{

    public Camera imageEffectsCamera;
    public Transform waterPlane;
    public float pos_y;
    public Transform player_y;
    public float player_pos_y;

    // Start is called before the first frame update
    void Start()
    {
       
        imageEffectsCamera.GetComponent<myDisplace>().enabled = false;
        imageEffectsCamera.GetComponent<myBlur>().enabled = false;
    }

    // Update is called once per frame
    public void Update()
    {
        player_pos_y = player_y.transform.position.y;
        pos_y = waterPlane.transform.position.y;

        if (player_pos_y <= pos_y) 
        {
            imageEffectsCamera.GetComponent<myDisplace>().enabled = true;
            imageEffectsCamera.GetComponent<myBlur>().enabled = true;

        }

        if (player_pos_y >= pos_y)
        {
            imageEffectsCamera.GetComponent<myDisplace>().enabled = false;
            imageEffectsCamera.GetComponent<myBlur>().enabled = false;

        }
    }

}
