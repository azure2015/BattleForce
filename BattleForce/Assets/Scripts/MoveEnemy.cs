using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] int direction;    //1 - down
    [SerializeField] float moveSpeed;

    float lifeSpan = 8.0f;

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

            default:
                moveDown();
                break;
        }

        checkRemove();
    }

    void checkRemove()
    {
        if(transform.position.y < -lifeSpan)
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
}