using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackController : MonoBehaviour
{
    public static AttackController instance;

    //チェック中のゴミ箱の種類
    public string nowDustBoxName;

    //チェック中のゴミ箱コマンド配列
    string[] nowDustBoxCommand;

    //チェック中の配列番号
    public int nowCount = 0;

    //アニメーション用配列番号
    public int animationCount = 0;

    //空のゴミ箱コマンド配列
    string[] emptyDustBoxCommand = new string[] { "Open", "Close" };

    //満タンのゴミ箱コマンド配列
    string[] fullDustBoxCommand = new string[] { "Open", "PickUp", "Close" };

    //クマのゴミ箱コマンド配列
    string[] bearDustBoxCommand = new string[] { "Open", "Kick", "Close" };

    //爆弾のゴミ箱コマンド配列
    string[] bombDustBoxCommand = new string[] { "Open", "Close", "Kick" };

    private GameObject centerDustBox;

    public Button openButton;
    public Button closeButton;
    public Button kickButton;
    public Button pickUpButton;

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

    }

    //
    public void SetDustBox(string dustBoxName)
    {
        nowDustBoxName = dustBoxName;

        //空のゴミ箱だったら
        if(nowDustBoxName.Contains("Empty"))
        {
            //複製する配列の長さで初期化
            nowDustBoxCommand = new string[emptyDustBoxCommand.Length];

            //チェック中のゴミ箱コマンド配列に、空のゴミ箱コマンド配列を複製
            Array.Copy(emptyDustBoxCommand, nowDustBoxCommand, emptyDustBoxCommand.Length);
        }
        else if(nowDustBoxName.Contains("Full"))
        {
            //複製する配列の長さで初期化
            nowDustBoxCommand = new string[fullDustBoxCommand.Length];

            //チェック中のゴミ箱コマンド配列に、空のゴミ箱コマンド配列を複製
            Array.Copy(fullDustBoxCommand, nowDustBoxCommand, fullDustBoxCommand.Length);
        }
        else if(nowDustBoxName.Contains("Bear"))
        {
            //複製する配列の長さで初期化
            nowDustBoxCommand = new string[bearDustBoxCommand.Length];

            //チェック中のゴミ箱コマンド配列に、空のゴミ箱コマンド配列を複製
            Array.Copy(bearDustBoxCommand, nowDustBoxCommand, bearDustBoxCommand.Length);
        }
        else if(nowDustBoxName.Contains("Bomb"))
        {
            //複製する配列の長さで初期化
            nowDustBoxCommand = new string[bombDustBoxCommand.Length];

            //チェック中のゴミ箱コマンド配列に、空のゴミ箱コマンド配列を複製
            Array.Copy(bombDustBoxCommand, nowDustBoxCommand, bombDustBoxCommand.Length);
        }
    }

    //コマンドボタン押したときに行われる処理
    public void TapActionCommand(string action)
    {
        //Debug.Log(nowCount);

        //正解のコマンド
        string correctCommand = nowDustBoxCommand[nowCount];

        if(action == "Kick")
        {
            UIAnimationController.instance.FootKick();

            //centerDustBox = GameObject.Find("CenterDustBox");
            //Animator animator_tmp = centerDustBox.GetComponent<Animator>();
            //animator_tmp.SetBool("Kick", true);
        }

        //Debug.Log("正解は" + correctCommand + " 入力コマンドは" + action);

        //正解だったら
        if (correctCommand == action)
        {
            //チェック中の配列番号を+1
            nowCount++;
            animationCount++;

            //チェック中の配列番号が、配列の要素総数を超えていたら次のゴミ箱へ
            if(nowCount == nowDustBoxCommand.Length)
            {
                UIAnimationController.instance.Maru();

                //チェック中の配列番号を初期化
                nowCount = 0;

                //次のゴミ箱へ
                GameController.instance.NextDustBox();

                //スコアに+1点
                UIController.instance.addScore(1);
            }
        }
        //不正解だったら
        else
        {
            //失敗エフェクト用にカウントに-1代入
            //animationCount = -1;

            //ボタン非活性化
            StartCoroutine("NotInteractable");

            if (nowDustBoxName.Contains("Bomb"))
            {
                UIAnimationController.instance.Explosion();
            }
            else
            {
                UIAnimationController.instance.Batsu();
            }
            
            //チェック中の配列番号を初期化
            nowCount = 0;

            //次のゴミ箱へ
            GameController.instance.NextDustBox();
        }
    }


    private IEnumerator NotInteractable()
    {
        openButton.interactable = false;
        closeButton.interactable = false;
        kickButton.interactable = false;
        pickUpButton.interactable = false;

        yield return new WaitForSeconds(0.5f);

        openButton.interactable = true;
        closeButton.interactable = true;
        kickButton.interactable = true;
        pickUpButton.interactable = true;
    }

}
