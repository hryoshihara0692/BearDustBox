using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public TextMeshProUGUI score;

    //カウントダウン
    private float countdown = 30.0f;

    //時間を表示するText型の変数
    public TextMeshProUGUI timerText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //時間をカウントダウンする
        countdown -= Time.deltaTime;

        //時間を表示する
        timerText.text = countdown.ToString("f1") + "Sec";

        //countdownが0以下になったとき
        if (countdown <= 0)
        {
            timerText.text = "Finish!!";
        }
    }

    //スコア追加
    public void addScore(int addScore)
    {
        score.text = (int.Parse(score.text) + addScore).ToString("00000");
    }
}
