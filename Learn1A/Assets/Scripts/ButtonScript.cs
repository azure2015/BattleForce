using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
   
    public void add()
    {
        ScoreText_Single.Instance.AddScore(5);
        Debug.Log(ScoreText_Single.Instance.GetScore());
    }

    public void ButtonClicked()
    {
        ScoreText_Single.Instance.AddScore(5);
        Debug.Log(ScoreText_Single.Instance.GetScore());
    }
}
