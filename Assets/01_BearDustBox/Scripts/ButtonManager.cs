using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    //ボタンタップで呼ばれるメソッド
    public void TappedButton()
    {
        SEManager seManager = SEManager.Instance;
        seManager.SettingPlaySE();
        SceneManager.LoadScene("GameScene");
    }
}
