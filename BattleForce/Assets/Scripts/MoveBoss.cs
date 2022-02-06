using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoss : MonoBehaviour
{

    [SerializeField] int hitPoints = 10;
    [SerializeField] float moveSpeed = 3.0f;
    [SerializeField] float minLeft = -2.8f;
    [SerializeField] float maxRight = 2.4f;

    [SerializeField] GameObject bossBullet;
    [SerializeField] float fireRateMax = 2.0f;
    [SerializeField] float fireRateMin = .5f;

    [SerializeField] GameObject endExplosion;

    [SerializeField] List<string> Actions = new List<string> { "Left", "Right", "Center","Left", "Right" };
    float timer = 4f;
    float timeLeft;

    int currentIndex = 0;
    string currentAction;
    bool isCenter = false;
    bool isDestroy = false;

  //  Animator anim;

    
    // Start is called before the first frame update
    void Start()
    {
     //   anim = GetComponent<Animator>();
        currentAction = "Down";
        timeLeft = Random.Range(fireRateMin, fireRateMax);

    }

    // Update is called once per frame
    void Update()
    {
        if (!isDestroy)
        {
            if (timer < 0)
            {
                timer = 4f;
                currentIndex = (currentIndex >= Actions.Count - 1) ? 0 : currentIndex + 1;
                currentAction = Actions[currentIndex];
                isCenter = false;

            }
            timer -= Time.deltaTime;

            switch (currentAction)
            {
                case "Left":
                    moveLeft();
                    break;
                case "Right":
                    moveRight();
                    break;
                case "Center":
                    moveCenter();
                    break;
                case "Down":
                    moveDown();
                    break;
                default:
                    break;
            }

            CheckBossFireBullet();
        }
        BossDestroyed();

    }

    void CheckBossFireBullet()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            GameObject EnemyBullet = Instantiate(bossBullet, transform.position, Quaternion.identity);
            timeLeft = Random.Range(fireRateMin, fireRateMax);
        }
    }
    void moveLeft()
    {
        if (transform.position.x > minLeft)
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
    }

    void moveDown()
    {
            transform.position = new Vector2(transform.position.x, transform.position.y - (moveSpeed/5) * Time.deltaTime);
    }

    void moveRight()
    {
        if (transform.position.x < maxRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
    }

    void moveCenter()
    {
        if(transform.position.x < -0.2 && !isCenter )
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        } else if (transform.position.x > 0.2 && !isCenter)
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        } else
        {
            isCenter = true;
        }
    }

    void BossDestroyed()
    {
        if(isDestroy)
        {
            timeLeft -= Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            if (timeLeft < 0)
            {
                FindObjectOfType<GameSession>().NextLevel();
            }
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet" && transform.childCount == 0)
        {
            hitPoints--;
            if(hitPoints <0 )
            {
                Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z +10.0f) ;
                Instantiate(endExplosion, pos, Quaternion.identity);
                isDestroy = true;
                timeLeft = 3.0f;
            }
        }
    }


}
