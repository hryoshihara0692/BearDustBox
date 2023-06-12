using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimationController : MonoBehaviour
{
    //public static UIAnimationController instance;

    private static UIAnimationController instance;

    public static UIAnimationController Instance
    {
        get { return instance; }
    }

    //正解アニメーションゲームオブジェクト
    public GameObject maru;
    public GameObject good;

    //不正解アニメーションゲームオブジェクト
    public GameObject batsu;
    public GameObject bad;

    //爆発アニメーションゲームオブジェクト
    public GameObject explosion;

    public GameObject footKick;

    public GameObject footKickImpact;

    AudioSource audioSource;
    public AudioClip maruClip;
    public AudioClip batsuClip;
    public AudioClip explosionClip;

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        //Destroy(gameObject);
    //    }
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

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Maru()
    {
        audioSource.clip = maruClip;
        audioSource.Play();
        Instantiate(maru, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Instantiate(good, new Vector3(1f, 1f, 0f), Quaternion.identity);
    }

    public void Batsu()
    {
        audioSource.clip = batsuClip;
        audioSource.Play();
        Instantiate(batsu, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Instantiate(bad, new Vector3(-1f, 1f, 0f), Quaternion.identity);
    }

    public void Explosion()
    {
        audioSource.clip = explosionClip;
        audioSource.Play();

        //爆発アニメーションゲームオブジェクトの生成
        Instantiate(explosion, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Instantiate(bad, new Vector3(-1f, 1f, 0f), Quaternion.identity);
        Instantiate(batsu, new Vector3(0f, 0f, 0f), Quaternion.identity);

    }

    public void FootKick()
    {
        Instantiate(footKick, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Instantiate(footKickImpact, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }
}
