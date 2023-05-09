using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    //アニメーター取得フラグ
    private bool getAnimation = false;
    //ゴミ箱アニメーター
    private Animator animatorDustBox;
    //一時ゲームオブジェクト
    //private GameObject tmpGameObject;
    //爆発スプライトレンダラー
    //private SpriteRenderer SRExplosion;
    //爆発アニメーター
    //private Animator animatorExplosion;
    //爆発アニメーションゲームオブジェクト
    public GameObject explosion;
    
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

            //if(animatorDustBox.name.Contains("Bomb"))
            //{
            //    Debug.Log("ぼむ");
            //    //子オブジェクトを取得
            //    tmpGameObject = transform.GetChild(0).gameObject;
            //    //子オブジェクトのスプライトレンダラー取得
            //    SRExplosion = tmpGameObject.GetComponent<SpriteRenderer>();
            //    //子オブジェクトのアニメーター取得
            //    animatorExplosion = tmpGameObject.GetComponent<Animator>();
            //    Debug.Log("もろもろ取得OK");
            //}

            //アニメーター取得フラグをオンにする
            getAnimation = true;

            //自ゴミ箱用にアニメーションカウントを初期化
            AttackController.instance.animationCount = 0;
        }

        if (getAnimation)
        {
            //チェック中の配列番号をセット
            animatorDustBox.SetInteger("nowCount", AttackController.instance.animationCount);
        }
    }

    public void Hello()
    {
        Debug.Log("Hello");
        ////Debug.Log("ぼむ");
        ////子オブジェクトを取得
        //tmpGameObject = transform.GetChild(0).gameObject;
        ////子オブジェクトのスプライトレンダラー取得
        //SRExplosion = tmpGameObject.GetComponent<SpriteRenderer>();
        ////子オブジェクトのアニメーター取得
        //animatorExplosion = tmpGameObject.GetComponent<Animator>();
        ////Debug.Log("もろもろ取得OK");

        ////透過処理を解除
        ////SRExplosion.color = new Color(255, 255, 255, 255);
        ////
        //animatorExplosion.SetInteger("startCount", 1);

        //爆発アニメーションゲームオブジェクトの生成
        Instantiate(explosion, new Vector3(0f, 0f, 0f), Quaternion.identity);

        //TODO NG処理はいずれまとめよう
        GameController.instance.NextDustBox();

        Debug.Log("all finish");

    }
}
