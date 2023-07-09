using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    //　ポーズUIのインスタンス
    [SerializeField]
    private GameObject settingUIInstance;

    [SerializeField]
    private GameObject archivementUIInstance;

    [SerializeField]
    private GameObject notRankingUIInstance;

    private bool settingActiveFlag = false;

    private bool archivementActiveFlag = false;

    private bool notRankingActiveFlag = false;

    public TextMeshProUGUI playSum;
    public TextMeshProUGUI maruSum;
    public TextMeshProUGUI batsuSum;
    public TextMeshProUGUI emptySum;
    public TextMeshProUGUI fullSum;
    public TextMeshProUGUI bearSum;
    public TextMeshProUGUI bombSum;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ボタンからモードを取得してゲームを開始する
    public void GameStart(string modeName)
    {
        if(modeName == "Normal")
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    public void setting()
    {
        if (!settingActiveFlag)
        {
            Debug.Log("ima");
            //pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
            settingUIInstance.SetActive(true);
            settingActiveFlag = true;
            //Time.timeScale = 0f;
        }
        else
        {
            //Destroy(pauseUIInstance);
            settingUIInstance.SetActive(false);
            settingActiveFlag = false;
            //Time.timeScale = 1f;
        }
    }

    public void Archivement()
    {
        if (!archivementActiveFlag)
        {
            //pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
            archivementUIInstance.SetActive(true);
            archivementActiveFlag = true;
            //Time.timeScale = 0f;

            if (ES3.KeyExists("Play_Sum"))
            {
                playSum.text = ES3.Load<int>("Play_Sum").ToString() + "回";
            }
            if (ES3.KeyExists("Maru_Sum"))
            {
                maruSum.text = ES3.Load<int>("Maru_Sum").ToString() + "箱";
            }
            if (ES3.KeyExists("Batsu_Sum"))
            {
                batsuSum.text = ES3.Load<int>("Batsu_Sum").ToString() + "箱";
            }
            if (ES3.KeyExists("EmptyDustBox_Sum"))
            {
                emptySum.text = ES3.Load<int>("EmptyDustBox_Sum").ToString() + "箱";
            }
            if (ES3.KeyExists("FullDustBox_Sum"))
            {
                fullSum.text = ES3.Load<int>("FullDustBox_Sum").ToString() + "箱";
            }
            if (ES3.KeyExists("BearDustBox_Sum"))
            {
                bearSum.text = ES3.Load<int>("BearDustBox_Sum").ToString() + "箱";
            }
            if (ES3.KeyExists("BombDustBox_Sum"))
            {
                bombSum.text = ES3.Load<int>("BombDustBox_Sum").ToString() + "箱";
            }
        }
        else
        {
            //Destroy(pauseUIInstance);
            archivementUIInstance.SetActive(false);
            archivementActiveFlag = false;
            //Time.timeScale = 1f;
        }
    }

    public void NotRanking()
    {
        if (notRankingActiveFlag)
        {
            notRankingUIInstance.SetActive(false);
            notRankingActiveFlag = false;
        }
        else if (!notRankingActiveFlag && !ES3.Load<bool>("AuthCheck"))
        {
            notRankingUIInstance.SetActive(true);
            notRankingActiveFlag = true;
        }
        else if (!notRankingActiveFlag && ES3.Load<bool>("AuthCheck"))
        {
            Social.ShowLeaderboardUI();
        }
    }
}
