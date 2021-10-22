using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //public variables
    public float speed;
    public PlayerController player;
    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed* Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("destroyer"))
        {
            //do something
            if (other.CompareTag("Player"))
            {
                player.hitObstacle = true;
            }
            Destroy(gameObject);
            
        }
        
    }
}
