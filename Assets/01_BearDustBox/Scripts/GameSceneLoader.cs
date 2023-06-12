using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneLoader : MonoBehaviour
{
    private void Start()
    {
        // MySingletonのインスタンスが存在しない場合、生成する
        if (GameController.Instance == null)
        {
            GameObject gameControllerObj = new GameObject("GameController");
            gameControllerObj.AddComponent<GameController>();
        }

        // MySingletonのインスタンスが存在しない場合、生成する
        if (AttackController.Instance == null)
        {
            GameObject attackControllerObj = new GameObject("AttackController");
            attackControllerObj.AddComponent<AttackController>();
        }

        // MySingletonのインスタンスが存在しない場合、生成する
        if (UIController.Instance == null)
        {
            GameObject uiControllerObj = new GameObject("UIController");
            uiControllerObj.AddComponent<UIController>();
        }

        // MySingletonのインスタンスが存在しない場合、生成する
        if (UIAnimationController.Instance == null)
        {
            GameObject uiAnimationControllerObj = new GameObject("UIAnimationController");
            uiAnimationControllerObj.AddComponent<UIAnimationController>();
        }

        // MySingletonのインスタンスが存在しない場合、生成する
        if (BGMController.Instance == null)
        {
            GameObject bgmControllerObj = new GameObject("BGMController");
            bgmControllerObj.AddComponent<BGMController>();
        }
    }

    private void OnDestroy()
    {
        // シーンが切り替わる際にMySingletonのインスタンスを破棄する
        if (GameController.Instance != null)
        {
            Destroy(GameController.Instance.gameObject);
        }
        // シーンが切り替わる際にMySingletonのインスタンスを破棄する
        if (AttackController.Instance != null)
        {
            Destroy(AttackController.Instance.gameObject);
        }
        // シーンが切り替わる際にMySingletonのインスタンスを破棄する
        if (UIController.Instance != null)
        {
            Destroy(UIController.Instance.gameObject);
        }
        // シーンが切り替わる際にMySingletonのインスタンスを破棄する
        if (UIAnimationController.Instance != null)
        {
            Destroy(UIAnimationController.Instance.gameObject);
        }

        if (BGMController.Instance != null)
        {
            Destroy(BGMController.Instance.gameObject);
        }
    }
}
