using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
  //  [SerializeField] float bulletLife = 2.5f;
    [SerializeField] int bulletType;
    
    float lifeSpan;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletType == 1)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + bulletSpeed * Time.deltaTime);
            if (transform.position.y > 10)
            {
                Destroy(gameObject);
            }
        }

        if (bulletType == 2)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + bulletSpeed * Time.deltaTime);
        }

        if (bulletType == 3)
        {
            transform.position = new Vector2(transform.position.x +( bulletSpeed / 2) * Time.deltaTime, transform.position.y + bulletSpeed * Time.deltaTime);
        }
        if (bulletType == 4)
        {
            transform.position = new Vector2(transform.position.x - (bulletSpeed / 2) * Time.deltaTime, transform.position.y + bulletSpeed * Time.deltaTime);
        }
     

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (bulletType == 1)
        {
            if (collision.tag == "Enemy")
            {
                
                Destroy(gameObject);
            }
        }

        if (bulletType >2)
        {
            var par = transform.parent.gameObject;

            if (collision.tag == "Boundary")
            {

                if (par.name == "BulletSpray(Clone)")
                {
                    Destroy(par);
                }
                Destroy(gameObject);
            }
        }

        if (bulletType == 2 )
        {

            if(collision.tag == "Player" || collision.tag == "Boundary")
            {
      
                Destroy(gameObject);
            }
        }
    }
}
