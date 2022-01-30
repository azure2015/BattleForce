using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] int direction;    //1 - down
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float fireRateMax = 3.0f;
    [SerializeField] float fireRateMin = 1.0f;

    float lifeSpan = 5.0f;
    float timeLeft;

    void Start()
    {
        timeLeft = Random.Range(fireRateMin, fireRateMax);    
    }
    // Update is called once per frame
    void Update()
    {
       switch(direction)
        {
            case 1: 
                moveDown();
                break;
            case 2:
                moveRightDown();
                break;
            case 3:
                moveLeftDown();
                break;
            case 4:
                moveLeftToRight();
                break;
            case 5:
                moveRightToLeft();
                break;

            default:
                moveDown();
                break;
        }

        timeLeft -= Time.deltaTime;
        if(timeLeft<=0 )
        {
            GameObject EnemyBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            timeLeft = Random.Range(fireRateMin, fireRateMax);
        }

   //     checkRemove();

    }

  
    void checkRemove()
    {
        lifeSpan -= Time.deltaTime;
        if(lifeSpan <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boundary")
        {

            Destroy(gameObject);
        }
    }
    void moveDown()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
    }

    void moveRightDown()
    {
        transform.position = new Vector2(transform.position.x + (moveSpeed /2) * Time.deltaTime, transform.position.y - moveSpeed * Time.deltaTime);
    }

    void moveLeftDown()
    {
        transform.position = new Vector2(transform.position.x - (moveSpeed / 2) * Time.deltaTime, transform.position.y - moveSpeed * Time.deltaTime);
    }

    void moveLeftToRight()
    {
        transform.position = new Vector2(transform.position.x + (moveSpeed * Time.deltaTime), transform.position.y);

    }
    void moveRightToLeft()
    {
        transform.position = new Vector2(transform.position.x - (moveSpeed * Time.deltaTime), transform.position.y);

    }
}
