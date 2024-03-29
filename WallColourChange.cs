using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColourChange : MonoBehaviour
{

    public Material newMaterialRef;
    public Material oldMaterialRef;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<MeshRenderer>().material = newMaterialRef;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<MeshRenderer>().material = oldMaterialRef;
        }
    }
}
