using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText_Single : MonoBehaviour
{
    private TMP_Text _text;
    private int score;

    public static ScoreText_Single Instance {get; set; }
   

    void Awake()
    {
        _text = GetComponent<TMP_Text>();
        Instance = this;
        Debug.Log("Here");
    }

    // Update is called once per frame
    public void AddScore(int value)
    {
        score += value;
        _text.SetText(score.ToString());
    }

    public int GetScore()
    {
        return score;
    }
}
