using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public GameObject player;
    bool canFind = true;
    NavMeshAgent agent;

    void Start()
    {
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (canFind)
        {
            StartCoroutine(find());
        }
    }

    // Function to apply damage to the enemy
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Check if health is less than or equal to 0
        if (currentHealth <= 0)
        {
            // If health is 0 or below, destroy the enemy
            DestroyEnemy();
        }
    }

    // Function to handle the destruction of the enemy
    void DestroyEnemy()
    {
        // Add any additional cleanup logic here
        Destroy(gameObject);
    }
    IEnumerator find()
    {
        canFind = false;

        yield return new WaitForSeconds(2);

        agent.SetDestination(player.transform.position);

        canFind = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovementScript>().TakeDamage(10);
            Destroy(this.gameObject);
        }
    }
}
