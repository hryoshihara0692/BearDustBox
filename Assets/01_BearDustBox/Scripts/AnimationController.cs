using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    //アニメーション取得フラグ
    private bool getAnimation = false;
    //アニメーション
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //ゴミ箱が真ん中かつ、アニメーション未取得
        if(transform.position.x == 0 && !getAnimation)
        {
            //アニメーション取得
            animator = GetComponent<Animator>();

            //アニメーション取得フラグをオンにする
            getAnimation = true;

            //自ゴミ箱用にアニメーションカウントを初期化
            AttackController.instance.animationCount = 0;
        }

        if (getAnimation)
        {
            //チェック中の配列番号をセット
            animator.SetInteger("nowCount", AttackController.instance.animationCount);
        }
    }
}
