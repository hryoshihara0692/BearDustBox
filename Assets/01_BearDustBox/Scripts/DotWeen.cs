using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DotWeen : MonoBehaviour
{
    [SerializeField]
    Vector3 targetPosition = new Vector3(1.5f, 0, 0);
    [SerializeField]
    float duration = 1;
    [SerializeField]
    Ease ease = Ease.Linear;

    void Start()
    {
        transform.DOJump(transform.position, 20f, 2, duration).SetLoops(-1, LoopType.Yoyo).SetEase(ease);
    }
}
