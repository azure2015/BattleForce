using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveSky : MonoBehaviour
{
    [SerializeField] GameObject camPosition;
    float lifeSpan = 18.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeSpan -= Time.deltaTime;
        if (lifeSpan < 0)
        {
            lifeSpan = 18.0f;
            transform.position = new Vector2(camPosition.transform.position.x, camPosition.transform.position.y+4.0f);
        }
        transform.position = new Vector2(transform.position.x, transform.position.y - (1.0f * Time.deltaTime)); 
    }
}
