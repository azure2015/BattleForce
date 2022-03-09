using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] GameObject TankBullet;
    [SerializeField] float fireRateMax = 3.0f;
    [SerializeField] float fireRateMin = 1.0f;

    float timeLeft;

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            GameObject EnemyBullet = Instantiate(TankBullet, transform.position, Quaternion.identity);
            timeLeft = Random.Range(fireRateMin, fireRateMax);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Boundary")
        {
            Destroy(gameObject);
        }
    }
}
