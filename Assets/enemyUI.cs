using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3;
    public float enemySpeed = 5f;
    public Transform player; // Reference to the player's transform
    public float detectionRange = 10f; // Range within which the enemy detects the player
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
        }



    }

    // Update is called once per frame
    void Update()
    {
        // Default patrol movement
                 
        rb.linearVelocity = new Vector2(enemySpeed, rb.linearVelocity.y);
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer < detectionRange)
        {
            // Move towards the player
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = new Vector2(direction.x * enemySpeed, rb.linearVelocity.y);
        }
        else
        {
            // Patrol behavior (e.g., move back and forth)
            rb.linearVelocity = new Vector2(enemySpeed, rb.linearVelocity.y);
        }

        // Flip sprite based on movement direction
        if (rb.linearVelocity.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (rb.linearVelocity.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Handle player collision (e.g., deal damage)
            Debug.Log("Enemy hit the player!");
            PlayerMove playerMove = collision.gameObject.GetComponent<PlayerMove>();
            if (playerMove != null)
            {
                playerMove.TakeDamage(1);
            }
            
            // Example: player takes damage when colliding with enemy
        }

    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemy took damage, remaining health: " + health);
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        // Handle enemy death (e.g., play animation, drop loot)
        Destroy(gameObject);
    }
}
