using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSourceSE;
    public AudioClip se;

    //public static SEManager Instance
    //{
    //    get; private set;
    //}

    private static SEManager instance;

    public static SEManager Instance
    {
        get { return instance; }
    }

    //void Awake()
    //{
    //    if (Instance != null)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }
    //    Instance = this;
    //    DontDestroyOnLoad(gameObject);
    //}

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        //audioSourceSE = this.GetComponent();
        audioSourceSE = this.GetComponent<AudioSource>();
    }

    public void SettingPlaySE()
    {
        audioSourceSE.PlayOneShot(se);
    }

}
