using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CountdownAddScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(new Vector3(0f, 0.75f, 0f), 0.25f);

        transform.DOScale(0f, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
