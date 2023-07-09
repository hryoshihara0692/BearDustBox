using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlaySum : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPlaySumNum()
    {
        //プレイ回数を保存
        if (ES3.KeyExists("Play_Sum"))
        {
            int prePlaySum = ES3.Load<int>("Play_Sum");
            ES3.Save<int>("Play_Sum", prePlaySum + 1);
        }
        else
        {
            ES3.Save<int>("Play_Sum", 1);
        }
    }
}
