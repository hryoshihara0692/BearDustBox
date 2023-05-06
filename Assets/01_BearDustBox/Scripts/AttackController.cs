using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public static AttackController instance;

    //チェック中のゴミ箱コマンド配列
    string[] nowDustBoxCommand;

    //チェック中の配列番号
    int nowCount = 0;

    //空のゴミ箱コマンド配列
    string[] emptyDustBoxCommand = new string[] { "Open", "Close" };

    //満タンのゴミ箱コマンド配列
    string[] fullDustBoxCommand = new string[] { "Open", "PickUp", "Close" };

    //クマのゴミ箱コマンド配列
    string[] bearDustBoxCommand = new string[] { "Open", "Kick", "Close" };

    //爆弾のゴミ箱コマンド配列
    string[] bombDustBoxCommand = new string[] { "Open", "Close", "Kick" };

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

    public void SetDustBox(string dustBoxName)
    {
        //空のゴミ箱だったら
        if(dustBoxName.Contains("Empty"))
        {
            //複製する配列の長さで初期化
            nowDustBoxCommand = new string[emptyDustBoxCommand.Length];

            //チェック中のゴミ箱コマンド配列に、空のゴミ箱コマンド配列を複製
            Array.Copy(emptyDustBoxCommand, nowDustBoxCommand, emptyDustBoxCommand.Length);
        }
        else if(dustBoxName.Contains("Full"))
        {
            //複製する配列の長さで初期化
            nowDustBoxCommand = new string[fullDustBoxCommand.Length];

            //チェック中のゴミ箱コマンド配列に、空のゴミ箱コマンド配列を複製
            Array.Copy(fullDustBoxCommand, nowDustBoxCommand, fullDustBoxCommand.Length);
        }
        else if(dustBoxName.Contains("Bear"))
        {
            //複製する配列の長さで初期化
            nowDustBoxCommand = new string[bearDustBoxCommand.Length];

            //チェック中のゴミ箱コマンド配列に、空のゴミ箱コマンド配列を複製
            Array.Copy(bearDustBoxCommand, nowDustBoxCommand, bearDustBoxCommand.Length);
        }
        else if(dustBoxName.Contains("Bomb"))
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
        //正解のコマンド
        string correctCommand = nowDustBoxCommand[nowCount];

        //正解だったら
        if(correctCommand == action)
        {
            //チェック中の配列番号を+1
            nowCount++;

            //チェック中の配列番号が、配列の要素総数を超えていたら次のゴミ箱へ
            if(nowCount == nowDustBoxCommand.Length)
            {
                //チェック中の配列番号を初期化
                nowCount = 0;

                //次のゴミ箱へ
                GameController.instance.NextDustBox();

                //スコアに+1点
                UIController.instance.addScore(1);
            }
            //TODO 必要に応じて配列初期化
        }
        //不正解だったら
        else
        {
            //チェック中の配列番号を初期化
            nowCount = 0;

            //次のゴミ箱へ
            GameController.instance.NextDustBox();
        }
    }


}
