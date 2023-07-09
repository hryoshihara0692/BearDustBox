using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultController : MonoBehaviour
{
    //public TextMeshProUGUI sumText;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI highScoreText;

    public GameObject highScoreUpdate;

    // Start is called before the first frame update
    void Start()
    {
        int score = ES3.Load<int>("DustBox_Score");

        scoreText.text = score.ToString() + "箱";

        if (ES3.KeyExists("DustBox_HighScore"))
        {
            if (score > ES3.Load<int>("DustBox_HighScore"))
            {
                ES3.Save<int>("DustBox_HighScore", score);
                SendScore(ES3.Load<int>("DustBox_HighScore"), "BestScore_DustBox");
                highScoreUpdate.SetActive(true);
            }
            highScoreText.text = ES3.Load<int>("DustBox_HighScore").ToString() + "箱";
            
        }
        else
        {
            ES3.Save<int>("DustBox_HighScore", score);
            highScoreText.text = score.ToString() + "箱";
            SendScore(ES3.Load<int>("DustBox_HighScore"), "BestScore_DustBox");
        }

        SendScore(ES3.Load<int>("Maru_Sum"), "AmmountDustBox");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendScore(int score, string leaderBoardId)
    {
        Social.ReportScore(score, leaderBoardId, success => {
            if (success)
            {
                // 送信が成功した時の処理
                Debug.Log("report success");
            }
            else
            {
                // 送信が失敗した時の処理
                Debug.Log("report fail");
            }
        });
    }
}
