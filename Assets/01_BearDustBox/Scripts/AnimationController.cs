using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    //アニメーター取得フラグ
    private bool getAnimation = false;

    //ゴミ箱アニメーター
    public Animator animatorDustBox;

    //爆発アニメーションゲームオブジェクト
    public GameObject explosion;

    //クマ攻撃アニメーションゲームオブジェクト
    public GameObject bearAttack;

    public GameObject bad;

    public GameObject batsu;

    //ゴミ箱終了フラグ
    private bool finishFlag = false;

    AudioSource audioSource;
    public AudioClip explosionClip;
    public AudioClip bearAttackClip;

    private GameObject openB;
    private GameObject closeB;
    private GameObject kickB;
    private GameObject pickUpB;

    public Button openButton;
    public Button closeButton;
    public Button kickButton;
    public Button pickUpButton;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        openB = GameObject.Find("Open");
        openButton = openB.GetComponent<Button>();
        closeB = GameObject.Find("Close");
        closeButton = closeB.GetComponent<Button>();
        kickB = GameObject.Find("Kick");
        kickButton = kickB.GetComponent<Button>();
        pickUpB = GameObject.Find("PickUp");
        pickUpButton = pickUpB.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        //ゴミ箱が真ん中かつ、アニメーター未取得
        if(transform.position.x == 0 && !getAnimation)
        {
            //アニメーター取得
            animatorDustBox = GetComponent<Animator>();

            //アニメーター取得フラグをオンにする
            getAnimation = true;

            //自ゴミ箱用にアニメーションカウントを初期化
            AttackController.Instance.animationCount = 0;
        }

        if (getAnimation && !finishFlag)
        {
            //Debug.Log(AttackController.Instance.animationCount);
            //チェック中の配列番号をセット
            animatorDustBox.SetInteger("nowCount", AttackController.Instance.animationCount);
        }

        ////ボタン間違えたときはアニメーション停止
        ////if (!finishFlag && AttackController.Instance.animationCount == -1)
        //if (AttackController.Instance.animationCount == -1)
        //{
        //    animatorDustBox.speed = 0;

        //    Debug.Log(AttackController.Instance.nowDustBoxName);

        //    //if (AttackController.Instance.nowDustBoxName.Contains("Bomb"))
        //    //{
        //    //    Instantiate(explosion, new Vector3(0f, 0f, 0f), Quaternion.identity);
        //    //}

        //    finishFlag = true;
        //}

        if (transform.position.x < 0)
        {
            //animatorDustBox.speed = 0;

            finishFlag = true;
        }
    }

    public void Explosion()
    {
        if(transform.position.x == 0)
        {
            //爆発＝NGなのでnowCountを0にする
            AttackController.Instance.nowCount = 0;

            //ボタン非活性化
            StartCoroutine("NGNotInteractable");

            audioSource.clip = explosionClip;
            audioSource.Play();

            //爆発アニメーションゲームオブジェクトの生成
            Instantiate(explosion, new Vector3(0f, 0f, 0f), Quaternion.identity);
            Instantiate(bad, new Vector3(-1f, 1f, 0f), Quaternion.identity);
            Instantiate(batsu, new Vector3(0f, 0f, 0f), Quaternion.identity);

            //カメラを揺らす
            UIController.Instance.Shake();

            //TODO NG処理はいずれまとめよう
            GameController.Instance.NextDustBox(0.5f);
        }
    }

    public void BearAttack()
    {
        if(transform.position.x == 0)
        {
            //くま攻撃＝NGなのでnowCountを0にする
            AttackController.Instance.nowCount = 0;

            //ボタン非活性化
            StartCoroutine("NGNotInteractable");

            audioSource.clip = bearAttackClip;
            audioSource.Play();

            //熊の攻撃アニメーションゲームオブジェクトの生成
            Instantiate(bearAttack, new Vector3(0f, 0f, 0f), Quaternion.identity);
            Instantiate(bad, new Vector3(-1f, 1f, 0f), Quaternion.identity);
            Instantiate(batsu, new Vector3(0f, 0f, 0f), Quaternion.identity);

            //カメラを揺らす
            UIController.Instance.Shake();

            //TODO NG処理はいずれまとめよう
            GameController.Instance.NextDustBox(0.5f);
        }
    }

    public void False()
    {
        animatorDustBox.speed = 0;

        //Debug.Log(AttackController.instance.nowDustBoxName);
        if (AttackController.Instance.nowDustBoxName.Contains("Bomb"))
        {
            Instantiate(explosion, new Vector3(0f, 0f, 0f), Quaternion.identity);
        }

    }

    private IEnumerator NGNotInteractable()
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
