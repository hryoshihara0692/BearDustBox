using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public bool startFlag = false;

    public TextMeshProUGUI score;
    private int scoreNum = 0;

    //カウントダウン
    private float countdown = 30.0f;

    //時間を表示するText型の変数
    public TextMeshProUGUI timerText;

    //残り時間表示スライダー
    public Slider slider;

    //画面振動するためのカメラ
    public GameObject mainCamera;
    [SerializeField] float duration = 0.5f;            // 揺れる時間
    [SerializeField] float strength = 0.5f;       // 揺れる幅
    [SerializeField] int vibrato = 10;          // 揺れる回数
    [SerializeField] float randomness = 90f;    // Indicates how much the shake will be random (0 to 180 ...
    [SerializeField] bool snapping = false;     // If TRUE the tween will smoothly snap all values to integers. 
    [SerializeField] bool fadeOut = true;       // 徐々に揺れが収まるか否か

    //開始テキスト
    public GameObject startText;
    public GameObject three;
    public GameObject two;
    public GameObject one;

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
        startText.SetActive(false);
        three.SetActive(false);
        two.SetActive(false);
        one.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (startFlag)
        {
            //時間をカウントダウンする
            countdown -= Time.deltaTime;

            //時間を表示する
            timerText.text = countdown.ToString("f1");

            //スライダーにカウントダウンを反映する
            slider.value = countdown;

            //countdownが0以下になったとき
            if (countdown <= 0)
            {
                timerText.text = "Finish!!";
                //SceneManager.LoadScene("ResultScene");
            }
        }
    }

    //スコア追加
    public void addScore(int addScore)
    {
        //スクリプトで保持しているint型のスコアに追加
        scoreNum = scoreNum + addScore;

        score.text = scoreNum.ToString() + "箱";
    }

    //カウントダウンの値増減
    public void addCountdown(float value)
    {
        countdown = countdown + value;
    }

    public void Shake()
    {
        mainCamera.transform.DOShakePosition(
            duration, strength, vibrato, randomness, snapping, fadeOut);
    }
}
