using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject camPosition;
    [SerializeField] float SpawnRate;

    BoxCollider2D colliderSize;
    float nextSpawn = 0.0f;
    float maxSize;
    bool isSpawn = false;

    Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        colliderSize = GetComponent<BoxCollider2D>();
        maxSize = Mathf.Round(colliderSize.size.x - 2) / 2;
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
                var randomXPos = Random.Range(-maxSize, maxSize);
                Vector2 startPosition = new Vector2(randomXPos, camPosition.transform.position.y);
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
