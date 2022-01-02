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

    int hitPoints = 3;

    Vector2 startPosition;
    Vector2 rawInput;

    void Awake()
    {
    //   startPosition = transform.position;
        startPosition = resetPosition.transform.position;
      
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

        if(transform.position.y <= -3.0)
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
            //  PlayerDeath();
            transform.position = new Vector3(transform.position.x, transform.position.y - 8.0f, transform.position.z); 
      
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
