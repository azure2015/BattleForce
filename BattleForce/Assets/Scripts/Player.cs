using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 1.5f;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject resetPosition;
    [SerializeField] Tilemap tilePosition;
    [SerializeField] GameObject endPosition;


    [SerializeField] GameObject bottomLevel;
    [SerializeField] GameObject topLevel;

    float minXPos = -4.9f; // -3.2f;
    float maxXPos = 4.4f;
     

    int hitPoints = 3;

    Vector2 startPosition;
    Vector2 rawInput;

    void Update()
    {
        //       if ((transform.position.x <= minXPos && rawInput.x ==-1))
        //       {
        //           rawInput.x = 0;
        //       }


        //       if(transform.position.x >= maxXPos && rawInput.x == 1)
        //       {
        //           rawInput.x = 0;
        //       }

        //     //  if(transform.position.y <= -3.0)
        //   //    {

        //     //      if(rawInput.y >= -1  && rawInput.y <0) rawInput.y = 0;
        ////       }
        ///
        if ((transform.position.x <= minXPos && rawInput.x < 0))
        {
            rawInput.x = 0;
        }


        if (transform.position.x >= maxXPos && rawInput.x > 0)
        {
            rawInput.x = 0;
        }

        if (transform.position.y >= topLevel.transform.position.y && rawInput.y > 0)
        {
            rawInput.y = 0;
        }

        if (transform.position.y <= bottomLevel.transform.position.y && rawInput.y < 0)
        {
            rawInput.y = 0;
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
            float yPos = endPosition.transform.position.y - resetPosition.transform.position.y;
            startPosition = tilePosition.transform.position;
            startPosition.y = startPosition.y + yPos;
            tilePosition.transform.position = startPosition;
   

        }
        if (collision.tag == "EnemyBullet" && hitPoints <= 0)
        {
            PlayerDeath();
        }
        else if (collision.tag == "EnemyBullet")
        {
            hitPoints--;
            Debug.Log("Player health : " + hitPoints);

        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            PlayerDeath();
        }
           
    }

    void PlayerDeath()
    {
        FindObjectOfType<GameSession>().ProcessPlayerDeath();
    }


}
