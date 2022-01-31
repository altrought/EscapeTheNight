using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{

    public float damage;

    public FlashDamage other;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }

   public void TakeDamage() 
    {

        Health.currentHealth -= damage;
        other.FlashFlash();

    }

    void Died() 
    {

        Health.currentHealth -= 100;
    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage();
            //other.FlashFlash();
            //getDamage = true;
        }
    


        if (collision.gameObject.tag == "Killer")
        {
            Died();
        }
    }

    private void FlashScreen() 
    { 
    
    
    }

   
}
