using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MisstakeCameraShaker : MonoBehaviour
{
    [SerializeField] GameObject shakeObject; // 揺らすオブジェクト
    //[SerializeField] GameObject[] shakeObjects; // 揺らすオブジェクト
    [SerializeField] float duration;            // 揺れる時間
    [SerializeField] float strength = 1f;       // 揺れる幅
    [SerializeField] int vibrato = 10;          // 揺れる回数
    [SerializeField] float randomness = 90f;    // Indicates how much the shake will be random (0 to 180 ...
    [SerializeField] bool snapping = false;     // If TRUE the tween will smoothly snap all values to integers. 
    [SerializeField] bool fadeOut = true;       // 徐々に揺れが収まるか否か

    //private void Update()
    //{
    //    if (Input.anyKeyDown)
    //    {
    //        Shake();
    //    }
    //}

    // DOTweenでオブジェクトをゆらす
    private void Shake()
    {
        //foreach (var shakeObject in shakeObjects)
        //{
            //shakeObject.transform.DOShakePosition(
            //    duration, strength, vibrato, randomness, snapping, fadeOut);


            // DOShakePosition は duration 以外の引数はオプション（指定しなければデフォルト値使用）
            // なので、以下のようにシンプルに書くこともできる
            // shakeObject.transform.DOShakePosition ( duration );
        //}
    }
}
