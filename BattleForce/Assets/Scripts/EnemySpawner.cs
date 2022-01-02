using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject camPosition;
    [SerializeField] float SpawnRate;

    float randX;
    float nextSpawn = 0.0f;

    bool isSpawn = false;

    Quaternion rotation;
    Vector2 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        rotation = new Quaternion();
        rotation[2] = 180f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpawn)
        {
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + SpawnRate;
                randX = Random.Range(-2f, 2f);
                startPosition = new Vector2(randX, camPosition.transform.position.y);
                Instantiate(enemy, startPosition, rotation);  // Quaternion.identity);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "CamCollision")
        {
            isSpawn = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "CamCollision")
        {
            isSpawn = false;
        }
    }
}
