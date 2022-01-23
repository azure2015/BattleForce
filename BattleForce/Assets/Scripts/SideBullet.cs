using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 3.0f;
    [SerializeField] int bulletType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletType == 1)
        {
            transform.position = new Vector2(transform.position.x + (bulletSpeed * Time.deltaTime), transform.position.y);

        }
        if (bulletType == 2)
        {
            transform.position = new Vector2(transform.position.x - (bulletSpeed * Time.deltaTime), transform.position.y);

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
