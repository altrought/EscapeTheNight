using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public NavMeshAgent agent;

    public bool tookDamage = false;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public int damageTaken;

    public TreeAnimated treeAnim;
    public attackingPoint attacks;
    //Patroling

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    private bool isCoroutineExecuting = false;
    private bool isOtherCoroutineExecuting = false;
    private bool isAttackCoroutineExecuting = false;
    //Attacking

    public float timeBetweenAttacks;
    public bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerIsInSightRange, playerInAttackRange;


    //Materials
    public Slider healthSlider;
    public float maxHealth;
    public float currentHealth;


    public enemyTookDamage changeColor;
    public playEnemySound sounds;

    private void Awake()
    {
        //player = GameObject.Find("First Person Controller").transform;
        player = GameObject.Find("AFPC_Player").transform;

        agent = GetComponent<NavMeshAgent>();

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
            //treeAnim.Notking();
        }

        if (playerIsInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }

        if (playerIsInSightRange && playerInAttackRange)
        {
            AttackPlayer();
            treeAnim.AttackAnim();
        }

        healthSlider.value = currentHealth;

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

    private void ChasePlayer()
    {


        agent.SetDestination(player.position);


    }
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {

            StartCoroutine(AttackCor());

            ////attack code here

            //Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            //rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            ////

            //alreadyAttacked = true;
            //Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    public void ResetAttack()
    {

        alreadyAttacked = false;
        treeAnim.NotAttacking();

    }


    public void TakeDamage()
    {
        healthSlider.value = currentHealth;

        currentHealth -= damageTaken;
        changeColor.ColorDamage();
        sounds.PlaySound();

        if (currentHealth <= 0)

        {
            //Invoke(nameof(DestroyEnemy), 1.5f);
            treeAnim.isDying();
            StartCoroutine(DeathCoroutine());
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
            TakeDamage();
            tookDamage = true;
            StartCoroutine(ExampleCoroutine());

        }
    }

    IEnumerator ExampleCoroutine()
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(1);

        // Code to execute after the delay
        tookDamage = false;
        changeColor.BackToNormalColor();
        isCoroutineExecuting = false;
    }

    IEnumerator DeathCoroutine()
    {
        if (isOtherCoroutineExecuting)
            yield break;

        isOtherCoroutineExecuting = true;

        yield return new WaitForSeconds(2);

        // Code to execute after the delay
        Invoke(nameof(DestroyEnemy), 0.5f);
        isOtherCoroutineExecuting = false;
    }

    IEnumerator AttackCor()
    {
        if (isAttackCoroutineExecuting)
            yield break;

        isAttackCoroutineExecuting = true;

        yield return new WaitForSeconds(1.3f);

        // Code to execute after the delay
        //attack code here

        //Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        //rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        //rb.AddForce(transform.up * 8f, ForceMode.Impulse);

        ////

        //alreadyAttacked = true;
        //Invoke(nameof(ResetAttack), timeBetweenAttacks);
        attacks.Attacks();
        alreadyAttacked = true;

        Invoke(nameof(ResetAttack), timeBetweenAttacks);

        isAttackCoroutineExecuting = false;
    }
}
