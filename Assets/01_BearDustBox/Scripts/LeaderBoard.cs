using UnityEngine;
using UnityEngine.SceneManagement;
public class LeaderBoard : MonoBehaviour
{
    public static LeaderBoard instance = null;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        // xxxSceneの部分に、一番最初の画面のシーンを記載する
        if (SceneManager.GetActiveScene().name == "MenuScene")
        {
            userAuth();
        }
    }
    public void userAuth()
    {
        Social.localUser.Authenticate(processAuthentication);
    }
    private void processAuthentication(bool success)
    {
        if (success)
        {
            Debug.Log("認証成功");
            ES3.Save<bool>("AuthCheck", true);
            //ES3.Save<bool>("AuthCheck", false);
        }
        else
        {
            Debug.Log("認証失敗");
            ES3.Save<bool>("AuthCheck", false);
        }
    }
}