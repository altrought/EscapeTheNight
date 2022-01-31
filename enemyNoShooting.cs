using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enemyNoShooting : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;

    private Transform t;
    private Transform hitPoint;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public int damageTaken;

    //Patroling

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    private bool isNewCoroutineExecuting = false;

    //Attacking

    //public float timeBetweenAttacks;
    bool alreadyAttacked;
    //public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerIsInSightRange, playerInAttackRange;


    //Materials
    //public Material green, red, yellow;
    public Slider healthSlider;
    public float maxHealth;
    public static float currentHealth;


    private bool isCoroutineExecuting = false;
    public enemyTookDamage changeColor;
    public playEnemySound sounds;
    private void Awake()
    {
        //player = GameObject.Find("First Person Controller").transform;
        player = GameObject.Find("AFPC_Player").transform;

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        t = this.transform;
        hitPoint = GameObject.FindGameObjectWithTag("Player Bullet").transform;

    }

    private void Start()
    {
        currentHealth = maxHealth;

    }


    private void Update()
    {
        //check for sight and attack range
        playerIsInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);


        if (!playerIsInSightRange && !playerInAttackRange)
        {
            Patroling();
        }

        if (playerIsInSightRange && !playerInAttackRange)
        {
            //ChasePlayer();

            StartCoroutine(ExampleCoroutine());

        }

        if (playerIsInSightRange && playerInAttackRange)
        {
            AttackPlayer();
        }

        healthSlider.value = currentHealth;


        var dist = Vector3.Distance(t.position, hitPoint.position);

        //Debug.Log(dist); // <2

        if (dist <= 2.5 && Input.GetKeyUp(KeyCode.Mouse0)) 
        {
            TakeDamage();
            StartCoroutine(ColorCoroutine());

        }
    }

    private void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }


        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
            Vector3 direction = walkPoint - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.15f);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;

        }

        //GetComponent<MeshRenderer>().material = green;

    }

    private void SearchWalkPoint()
    {
        //calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;

        }
    }

    private void WaitThenChase() 
    { 
    
    
    
    }

    IEnumerator ExampleCoroutine()
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(1.2f);

        // Code to execute after the delay
        ChasePlayer();
        isCoroutineExecuting = false;
    }

    private void ChasePlayer()
    {


        agent.SetDestination(player.position);

        //GetComponent<MeshRenderer>().material = yellow;


    }
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        //if (!alreadyAttacked)
        //{
        //    //attack code here

        //    Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        //    rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        //    rb.AddForce(transform.up * 8f, ForceMode.Impulse);

        //    //

        //    alreadyAttacked = true;
        //    Invoke(nameof(ResetAttack), timeBetweenAttacks);
        //}

        //GetComponent<MeshRenderer>().material = red;

    }

    private void ResetAttack()
    {

        alreadyAttacked = false;
    }


    public void TakeDamage()
    {
        healthSlider.value = currentHealth;

        currentHealth -= damageTaken;
        changeColor.ColorDamage();
        sounds.PlaySound();

        if (currentHealth <= 0)

        {
            Invoke(nameof(DestroyEnemy), 0.5f);
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player Bullet")
        {
            //TakeDamage();
            //StartCoroutine(ColorCoroutine());

        }


    }

    IEnumerator ColorCoroutine()
    {
        if (isNewCoroutineExecuting)
            yield break;

        isNewCoroutineExecuting = true;

        yield return new WaitForSeconds(0.5f);

        // Code to execute after the delay
        //TakeDamage();

        changeColor.BackToNormalColor();

        isNewCoroutineExecuting = false;
    }
}
