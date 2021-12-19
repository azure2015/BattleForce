using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] int direction;    //1 - down
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject bulletPrefab;

    float lifeSpan = 6.0f;
    Coroutine firing;
    IEnumerator fireGun;
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


       // if (firing == null)
       // {
       //     StopCoroutine(fireBullet());
       //     firing = StartCoroutine(fireBullet());
      //  } else if (firing !=null)
      //  {
            
         float randomNumber = Random.Range(1, 500);
            
        if (randomNumber == 1)
        {
                if (fireGun != null)
                    StopCoroutine(fireGun);

            fireGun = fireBullet();
            StartCoroutine(fireGun);
                //firing = null;
        }
   // }
    }

    IEnumerator fireBullet()
    {
        
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        Destroy(bullet, 3.0f);
        yield return new WaitForSeconds(3);
        
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
