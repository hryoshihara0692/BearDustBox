using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    //TODO セーブしたボリュームデータをフラグに入れる
    public bool volumeFlag = true;

    public Button volumeButton;

    public Sprite volumeOn;
    public Sprite volumeOff;

    // Start is called before the first frame update
    void Start()
    {
        //TODO セーブしたボリュームデータをフラグに入れる
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void volumeOnOff()
    {
        volumeFlag = !volumeFlag;

        if (volumeFlag)
        {
            volumeButton.GetComponent<Image>().sprite = volumeOn;
        }
        else
        {
            volumeButton.GetComponent<Image>().sprite = volumeOff;
        }
    }
}
