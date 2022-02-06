using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 32;
    [SerializeField] GameObject endExplosion;

    Animator anim;
    bool isDestroy = false;

    float timeLeft = 3.0f;

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
            Destroy(gameObject,4);
            isDestroy = true;
            timeLeft = 3.0f;
        }
        BossDestroyed();
    }

    void BossDestroyed()
    {

        if (isDestroy)
        {
            Debug.Log("Next level  " + FindObjectOfType<GameSession>().getLevel()); 
            timeLeft -= Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            if (timeLeft < 0)
            {
                Debug.Log("Next level");
                FindObjectOfType<GameSession>().NextLevel();
            }
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
