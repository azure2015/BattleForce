using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 1.5f;
    [SerializeField] Tilemap tileMap;
    [SerializeField] GameObject bullet;

    Vector2 startPosition;
    Vector2 rawInput;


    void Awake()
    {
        startPosition = tileMap.transform.position;
    }
    void Update()
    {   
        if ((transform.position.x <= -2.6 && rawInput.x ==-1))
        {
            rawInput.x = 0;
        }

        
        if(transform.position.x >= 1.7 && rawInput.x == 1)
        {
            rawInput.x = 0;
        }

        if(transform.position.y <= -2.0)
        {
            if(rawInput.y >= -1  && rawInput.y <0) rawInput.y = 0;
        }
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        transform.position += delta;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="EndLevel")
        {
            tileMap.transform.position = startPosition;
        }
        if (collision.tag == "EnemyBullet")
        {
            Destroy(gameObject);

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" )
        {
            Destroy(gameObject);
        }
        
    }



}
