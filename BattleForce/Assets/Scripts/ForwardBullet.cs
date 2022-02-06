using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardBullet : MonoBehaviour
{

    [SerializeField] Transform barrel;
    [SerializeField] Rigidbody2D bullet;
    // Start is called before the first frame update

    float timeDelay = .5f;
    bool isFiring = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFiring)
        {
            timeDelay -= Time.deltaTime;
            if (timeDelay < 0)
            {
                var firedBullet = Instantiate(bullet, barrel.position, barrel.rotation);
                firedBullet.AddForce(barrel.up * 224.0f);
                timeDelay = Random.Range(0.3f, 0.8f);
            }
        }
    }

    public void Stopped()
    {
        isFiring = false;
    }
}
