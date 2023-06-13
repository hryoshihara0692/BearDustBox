using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    //public static UIController instance;

    private static UIController instance;

    public static UIController Instance
    {
        get { return instance; }
    }

    public bool startFlag = false;

    public TextMeshProUGUI score;
    private int scoreNum = 0;

    //カウントダウン
    public float countdown = 30.0f;

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

    public GameObject finishText;

    public LoadingScene loadingScene;

    public Button openButton;
    public Button closeButton;
    public Button kickButton;
    public Button pickUpButton;

    private AudioSource audioSource;
    public AudioClip endGame;

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        //Destroy(gameObject);
    //    }
    //}

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        startText.SetActive(false);
        three.SetActive(false);
        two.SetActive(false);
        one.SetActive(false);

        audioSource = gameObject.GetComponent<AudioSource>();

        //ES3.DeleteFile("SaveFile.es3");
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

            if(5 < countdown && countdown < 10)
            {
                BGMController.Instance.SetPitch(1.2f);
            }
            else if (countdown < 5)
            {
                BGMController.Instance.SetPitch(1.5f);
            }
            //else if(countdown < 3)
            //{
            //    BGMController.Instance.SetPitch(1.75f);
            //}

            //countdownが0以下になったとき
            if (countdown <= 0)
            {
                timerText.text = "FINISH";

                openButton.interactable = false;
                closeButton.interactable = false;
                kickButton.interactable = false;
                pickUpButton.interactable = false;

                //Time.timeScale = 0f;

                //Debug.Log("a");
                audioSource.Play();

                //timerText.text = "Finish!!";
                finishText.SetActive(true);

                BGMController.Instance.BGMStop();

                StartCoroutine("FinishEnumerator");

                startFlag = false;
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

    private IEnumerator FinishEnumerator()
    {
        //TODO 音鳴らす
        //Debug.Log("kokokiteru");

        yield return new WaitForSeconds(1f);

        //Debug.Log("kokoha");

        ES3.Save<int>("DustBox_Score", scoreNum);

        //セーブデータにマルの数があれば
        if (ES3.KeyExists("Maru_Sum"))
        {
            int preMaruSum = ES3.Load<int>("Maru_Sum");
            ES3.Save<int>("Maru_Sum", preMaruSum + GameController.Instance.getMaru());
        }
        //なかったらそのままセーブ
        else
        {
            ES3.Save<int>("Maru_Sum", GameController.Instance.getMaru());
        }

        //セーブデータにバツの数があれば
        if (ES3.KeyExists("Batsu_Sum"))
        {
            int preBatsuSum = ES3.Load<int>("Batsu_Sum");
            ES3.Save<int>("Batsu_Sum", preBatsuSum + GameController.Instance.getBatsu());
        }
        //なかったらそのままセーブ
        else
        {
            ES3.Save<int>("Batsu_Sum", GameController.Instance.getBatsu());
        }

        //セーブデータに空ごみ箱の数があれば
        if (ES3.KeyExists("EmptyDustBox_Sum"))
        {
            int preEmptyDustBoxSum = ES3.Load<int>("EmptyDustBox_Sum");
            ES3.Save<int>("EmptyDustBox_Sum", preEmptyDustBoxSum + GameController.Instance.getEmptyDustBox());
        }
        //なかったらそのままセーブ
        else
        {
            ES3.Save<int>("EmptyDustBox_Sum", GameController.Instance.getEmptyDustBox());
        }

        //セーブデータにまんたんごみ箱の数があれば
        if (ES3.KeyExists("FullDustBox_Sum"))
        {
            int preFullDustBoxSum = ES3.Load<int>("FullDustBox_Sum");
            ES3.Save<int>("FullDustBox_Sum", preFullDustBoxSum + GameController.Instance.getFullDustBox());
        }
        //なかったらそのままセーブ
        else
        {
            ES3.Save<int>("FullDustBox_Sum", GameController.Instance.getFullDustBox());
        }

        //セーブデータにくまのごみ箱の数があれば
        if (ES3.KeyExists("BearDustBox_Sum"))
        {
            int preBearDustBoxSum = ES3.Load<int>("BearDustBox_Sum");
            ES3.Save<int>("BearDustBox_Sum", preBearDustBoxSum + GameController.Instance.getBearDustBox());
        }
        //なかったらそのままセーブ
        else
        {
            ES3.Save<int>("BearDustBox_Sum", GameController.Instance.getBearDustBox());
        }

        //セーブデータに爆弾のごみ箱の数があれば
        if (ES3.KeyExists("BombDustBox_Sum"))
        {
            int preBombDustBoxSum = ES3.Load<int>("BombDustBox_Sum");
            ES3.Save<int>("BombDustBox_Sum", preBombDustBoxSum + GameController.Instance.getBombDustBox());
        }
        //なかったらそのままセーブ
        else
        {
            ES3.Save<int>("BombDustBox_Sum", GameController.Instance.getBombDustBox());
        }

        //プレイ回数を保存
        if (ES3.KeyExists("Play_Sum"))
        {
            int prePlaySum = ES3.Load<int>("Play_Sum");
            ES3.Save<int>("Play_Sum", prePlaySum + 1);
        }
        else
        {
            ES3.Save<int>("Play_Sum", 1);
        }

        //Debug.Log("kokohadoudesuka");

        yield return new WaitForSeconds(0.5f);

        //SceneManager.LoadScene("ResultScene");
        loadingScene.LoadNextScene("ResultScene");


    }
}
