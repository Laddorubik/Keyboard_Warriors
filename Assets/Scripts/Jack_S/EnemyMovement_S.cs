using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement_S : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public GameObject enemyFirePoint; 

    public LayerMask whatIsGround, whatIsPlayer;

    public float enemyHealth;

    public GameObject pickupStar;

    //patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject enemyProjectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerActual").transform;
        agent = GetComponent<NavMeshAgent>();    
    }

    // Update is called once per frame
    void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 5f, whatIsGround))
            walkPointSet = true;
    }
    void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack code
            Rigidbody rb = Instantiate(enemyProjectile, enemyFirePoint.transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            rb.AddForce(enemyFirePoint.transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(enemyFirePoint.transform.up * 8f, ForceMode.Impulse);
            ///
            //Allows for enemy fire rate
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    void ResetAttack()
    {
        alreadyAttacked = false;
    }
    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0) Invoke(nameof(EnemyDie), 0.5f);
    }
    //Death state
    void EnemyDie()
    {
        Instantiate(pickupStar, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    
}
