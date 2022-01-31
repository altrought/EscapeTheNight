using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTookDamage : MonoBehaviour
{
    //public GameObject enemy;
    //public Color myColor;

    public Material[] material;
    [HideInInspector] public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
       
        rend.material = material[0];

        //Material M = gameObject.GetComponent<SpriteRenderer>().material;

        //Destroy(M);
    }

    // Update is called once per frame
    void Update()
    {
        //Renderer myRenderer = enemy.GetComponentInChildren<Renderer>();
        //Material mat = myRenderer.material;

        //float emission = Mathf.PingPong(Time.time, 1.0f);
        //Color baseColor = myColor; //Replace this with whatever you want for your base color at emission level '1'

        //Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

        //mat.SetColor("_EmissionColor", finalColor);
        //rend.material = material[1];

    }

    public void ColorDamage() 
    {
        rend.material = material[1];
        Debug.Log("COLOR CHANGED");

    }

    public void BackToNormalColor() 
    {
        rend.material = material[0];
        Debug.Log("BACK TO NORMAL");

    }
}
