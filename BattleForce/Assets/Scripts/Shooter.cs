using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = -10f;
    [SerializeField] float bulletLifetime = 5f; 
    [SerializeField] float firingRate = 2f;

    [Header("AI")]
    [SerializeField] float firingRateVariance = 10f;
    [SerializeField] float minimumFiringRate = 10f;

    bool isFiring = true;
    Coroutine firingCoroutine;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float randomNumber = Random.Range(1, 5);
        if(randomNumber==1)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }

    void Fire()
    {
        if(isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinously());
        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinously()
    {
        while(true)
        {
            GameObject instance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rigidbody2D = instance.GetComponent<Rigidbody2D>();
          
            if (rigidbody2D != null)
            {
                rigidbody2D.velocity = transform.up * bulletSpeed;
            }
            Destroy(instance, bulletLifetime);

         //   float timeToNextProjectile = Random.Range(firingRate - firingRateVariance, firingRate + firingRateVariance);
          //  timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);
            yield return new WaitForSeconds(firingRate);

        }
    }
}
