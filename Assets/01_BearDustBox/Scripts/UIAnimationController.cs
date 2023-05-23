using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimationController : MonoBehaviour
{
    public static UIAnimationController instance;

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

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Maru()
    {
        Instantiate(maru, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Instantiate(good, new Vector3(1f, 1f, 0f), Quaternion.identity);
    }

    public void Batsu()
    {
        Instantiate(batsu, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Instantiate(bad, new Vector3(-1f, 1f, 0f), Quaternion.identity);
    }

    public void Explosion()
    {
        //爆発アニメーションゲームオブジェクトの生成
        Instantiate(explosion, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Instantiate(bad, new Vector3(-1f, 1f, 0f), Quaternion.identity);

    }

    public void FootKick()
    {
        Instantiate(footKick, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Instantiate(footKickImpact, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }
}
