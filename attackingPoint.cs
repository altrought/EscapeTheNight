using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackingPoint : MonoBehaviour
{
    public Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Attacks();
    }

    public void Attacks()
    {

        Rigidbody rb = Instantiate(enemy.projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        rb.AddForce(transform.up * 1.2f, ForceMode.Impulse);

        //

      //  enemy.alreadyAttacked = true; 

      //Invoke(nameof(enemy.ResetAttack), enemy.timeBetweenAttacks);

    }
}
