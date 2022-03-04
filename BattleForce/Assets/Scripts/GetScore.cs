using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameSession scoreReference;


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Final Score : \n" + scoreReference.GetScore().ToString();
    }

}
