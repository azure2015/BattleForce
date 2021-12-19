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

    float lifeSpan = 6.0f;

    float timeLeft;
    Coroutine firingCoroutine;
    IEnumerator fireGun;

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

            default:
                moveDown();
                break;
        }

        timeLeft -= Time.deltaTime;
        if(timeLeft<=0 )
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            timeLeft = Random.Range(fireRateMin, fireRateMax);
        }



        //if (firingCoroutine == null)
        //{
        //    StopCoroutine(fireBullet());
        //    firingCoroutine = StartCoroutine(fireBullet());
        //}
        //else if (firingCoroutine != null)
        //{
        //    StopCoroutine(fireBullet());
        //    firingCoroutine = null;
        //}
            

    }

    //IEnumerator fireBullet()
    //{

    //    while (true)
    //    {
    //        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

    //        Destroy(bullet, 2.0f);
    //        yield return new WaitForSeconds(fireRate);
    //    }
    //}
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
