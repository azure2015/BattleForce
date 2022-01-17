using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPost : MonoBehaviour
{

    [SerializeField] int hitPoints = 36;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float fireRateMax = 3.0f;
    [SerializeField] float fireRateMin = 1.0f;

    Animator anim;
    float timeLeft;

 //   bool animIsPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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

        if(hitPoints <0 )
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            anim.Play("Explosion",0,0);
            hitPoints--;
        }
    }
}
