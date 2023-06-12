using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public LoadingScene loadingScene;

    public GameObject tutorial;

    //ボタンタップで呼ばれるメソッド
    public void TappedButton(string first)
    {
        SEManager seManager = SEManager.Instance;
        seManager.SettingPlaySE();

        //TODO
        //ES3.DeleteKey("Play_Sum");

        if (first != "first")
        {
            //プレイ回数を保存
            if (ES3.KeyExists("Play_Sum"))
            {
                loadingScene.LoadNextScene("GameScene");
            }
            else
            {
                tutorial.SetActive(true);
            }
        }
        else
        {
            loadingScene.LoadNextScene("GameScene");
        }

    }
}
