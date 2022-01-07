using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPost : MonoBehaviour
{

    [SerializeField] int hitPoints = 6;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float fireRateMax = 3.0f;
    [SerializeField] float fireRateMin = 1.0f;

    float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = Random.Range(fireRateMin, fireRateMax);
    }

    // Update is called once per frame
    void Update()
    {

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            GameObject EnemyBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            timeLeft = Random.Range(fireRateMin, fireRateMax);
        }

    }
}
