using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOTweenTest : MonoBehaviour
{
    [SerializeField]
    Vector3 targetPosition = new Vector3(1.5f, 0, 0);
    [SerializeField]
    float duration = 1;
    [SerializeField]
    Ease ease = Ease.Linear;

    void Start()
    {
        transform.DOMove(targetPosition, duration).SetLoops(-1, LoopType.Yoyo).SetEase(ease);
    }
}
