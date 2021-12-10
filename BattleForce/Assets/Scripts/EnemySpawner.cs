using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float SpawnRate;

    float randX;
    float nextSpawn = 0.0f;
    Vector2 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + SpawnRate;
            randX = Random.Range(-2f, 2f);
            startPosition = new Vector2(randX, transform.position.y);
            Instantiate(enemy, startPosition, Quaternion.identity);
        }
    }
}
