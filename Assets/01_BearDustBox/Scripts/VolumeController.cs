using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    //TODO セーブしたボリュームデータをフラグに入れる
    public bool volumeFlag = true;

    public Image volumeButton;

    public Sprite volumeOn;
    public Sprite volumeOff;



    // Start is called before the first frame update
    void Start()
    {
        //TODO セーブしたボリュームデータをフラグに入れる
        if (ES3.KeyExists("Volume"))
        {
            if (!ES3.Load<bool>("Volume"))
            {
                AudioListener.volume = 0f;
                volumeButton.sprite = volumeOff;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateVolume()
    {
        if (ES3.KeyExists("Volume"))
        {
            if (!ES3.Load<bool>("Volume"))
            {
                AudioListener.volume = 0f;
                volumeButton.sprite = volumeOff;
            }
            else
            {
                AudioListener.volume = 1f;
                volumeButton.sprite = volumeOn;
            }
        }
    }

    public void volumeOnOff()
    {
        volumeFlag = !volumeFlag;

        if (volumeFlag)
        {
            AudioListener.volume = 1f;
            volumeButton.sprite = volumeOn;
            ES3.Save<bool>("Volume", true);
        }
        else
        {
            AudioListener.volume = 0f;
            volumeButton.sprite = volumeOff;
            ES3.Save<bool>("Volume", false);
        }
    }
}
