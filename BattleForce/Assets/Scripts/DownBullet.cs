using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 3.0f;
    [SerializeField] int bulletType;


    // Update is called once per frame
    void Update()
    {
        if (bulletType == 1)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + (bulletSpeed * Time.deltaTime));

        }
        if (bulletType == 2)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - +(bulletSpeed * Time.deltaTime));

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Boundary")
        {

            Destroy(gameObject);
        }
    }
}
