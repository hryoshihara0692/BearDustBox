using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
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
}