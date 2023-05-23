using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    //アニメーター取得フラグ
    private bool getAnimation = false;

    //ゴミ箱アニメーター
    private Animator animatorDustBox;

    //爆発アニメーションゲームオブジェクト
    public GameObject explosion;

    //クマ攻撃アニメーションゲームオブジェクト
    public GameObject bearAttack;

    public GameObject bad;

    //ゴミ箱終了フラグ
    private bool finishFlag = false;

    // Start is called before the first frame update
    void Start()
    {

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
            AttackController.instance.animationCount = 0;
        }

        if (getAnimation && !finishFlag)
        {
            //チェック中の配列番号をセット
            animatorDustBox.SetInteger("nowCount", AttackController.instance.animationCount);
        }

        ////ボタン間違えたときはアニメーション停止
        //if(!finishFlag && AttackController.instance.animationCount == -1)
        //{
        //    animatorDustBox.speed = 0;

        //    Debug.Log(AttackController.instance.nowDustBoxName);
        //    if (AttackController.instance.nowDustBoxName.Contains("Bomb"))
        //    {
        //        Instantiate(explosion, new Vector3(0f, 0f, 0f), Quaternion.identity);
        //    }

        //    finishFlag = true;
        //}

        if(transform.position.x < 0)
        {
            animatorDustBox.speed = 0;

            finishFlag = true;
        }
    }

    public void Explosion()
    {

        //爆発＝NGなのでnowCountを0にする
        AttackController.instance.nowCount = 0;

        //爆発アニメーションゲームオブジェクトの生成
        Instantiate(explosion, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Instantiate(bad, new Vector3(-1f, 1f, 0f), Quaternion.identity);

        //カメラを揺らす
        UIController.instance.Shake();

        //TODO NG処理はいずれまとめよう
        GameController.instance.NextDustBox();
    }

    public void BearAttack()
    {

        //くま攻撃＝NGなのでnowCountを0にする
        AttackController.instance.nowCount = 0;

        //爆発アニメーションゲームオブジェクトの生成
        Instantiate(bearAttack, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Instantiate(bad, new Vector3(-1f, 1f, 0f), Quaternion.identity);

        //カメラを揺らす
        UIController.instance.Shake();

        //TODO NG処理はいずれまとめよう
        GameController.instance.NextDustBox();
    }

    public void False()
    {
        animatorDustBox.speed = 0;

        //Debug.Log(AttackController.instance.nowDustBoxName);
        if (AttackController.instance.nowDustBoxName.Contains("Bomb"))
        {
            Instantiate(explosion, new Vector3(0f, 0f, 0f), Quaternion.identity);
        }

    }
}
