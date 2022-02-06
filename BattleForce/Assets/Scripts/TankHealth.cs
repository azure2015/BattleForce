using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 32;
    [SerializeField] GameObject endExplosion;

    Animator anim;
    bool isDestroy = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hitPoints < 0 && !isDestroy)
        {
            Instantiate(endExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject,1);
            isDestroy = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit the base tank");
        if (collision.tag == "Bullet")
        {
            anim.Play("Explode_new", 0, 0);
            hitPoints--;
        }
    }
}
