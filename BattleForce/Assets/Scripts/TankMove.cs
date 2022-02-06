using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] float moveSpeed = 3.0f;
    [SerializeField] float minLeft = -2.8f;
    [SerializeField] float maxRight = 2.4f;

    [SerializeField] GameObject endExplosion;

    [SerializeField] List<string> Actions = new List<string> { "Down", "Up", "Down", "Up"};
    float timer = 4f;
    float timeLeft;

    int currentIndex = 0;
    string currentAction;
    bool isCenter = false;
    bool isDestroy = false;

    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentAction = "Down";

    }

    // Update is called once per frame
    void Update()
    {
        if (hitPoints < 0 && !isDestroy)
        {
            Instantiate(endExplosion, transform.position, Quaternion.identity);
            SpriteRenderer[] childRenders = GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer element in childRenders)
            {
                element.enabled = false;
            }

            FindObjectOfType<ForwardBullet>().Stopped();
            Destroy(gameObject, 4.2f);
            isDestroy = true;
            timeLeft = 4.0f;
        }
        BossDestroyed();

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
                case "Up":
                    moveUp();
                    break;
                default:
                    break;
            }

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
        transform.position = new Vector2(transform.position.x, transform.position.y - (moveSpeed / 5) * Time.deltaTime);
    }

    void moveUp()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + (moveSpeed / 5) * Time.deltaTime);
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
        if (transform.position.x < -0.2 && !isCenter)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else if (transform.position.x > 0.2 && !isCenter)
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            isCenter = true;
        }
    }

    void BossDestroyed()
    {
        if (isDestroy)
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
        Debug.Log("Hit the base tank");
        if (collision.tag == "Bullet")
        {
            anim.Play("Explode_new", 0, 0);
            hitPoints--;
        }
    }

}
