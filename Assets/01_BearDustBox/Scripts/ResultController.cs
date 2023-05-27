using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultController : MonoBehaviour
{
    public TextMeshProUGUI sumText;

    // Start is called before the first frame update
    void Start()
    {
        int score = ES3.Load<int>("DustBox_Score");

        if (ES3.KeyExists("DustBox_SUM"))
        {
            int sum = ES3.Load<int>("DustBox_SUM");
            sumText.text = (sum + score).ToString() + "箱";
            ES3.Save<int>("DustBox_SUM", sum + score);
        }
        else
        {
            Debug.Log("nai");
            Debug.Log("ResultControllerのscore");
            sumText.text = score.ToString() + "箱";
            ES3.Save<int>("DustBox_SUM", score);
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
