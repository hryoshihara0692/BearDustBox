using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSourceSE;
    public AudioClip se;

    public static SEManager Instance
    {
        get; private set;
    }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
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
