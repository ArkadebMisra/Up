using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Public variables
    public GameObject obstacle;
    public float startTimeBetweenSpawn;
    public float width, height;
    public Vector2 screenBounds;
    public Vector2 spawnBoundary;

    //Private Variables
    private float timeBetweenSpawn;
    

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,
                                                        Camera.main.transform.position.z));
        width = obstacle.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBetweenSpawn <= 0)
        {
            spawnBoundary = new Vector2(-screenBounds.x + width, screenBounds.x - width);
            transform.position = new Vector2(NextFloat(spawnBoundary.x, spawnBoundary.y), transform.position.y);
            Instantiate(obstacle, transform.position, Quaternion.identity);
            timeBetweenSpawn = startTimeBetweenSpawn;
        }
        else
        {
            timeBetweenSpawn -= Time.deltaTime;
        }
        
    }

    float NextFloat(float min, float max)
    {
        /*
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
        */
        return Random.Range(min, max);
    }
}
