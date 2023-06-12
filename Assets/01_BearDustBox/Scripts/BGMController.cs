using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    private static BGMController instance;

    public static BGMController Instance
    {
        get { return instance; }
    }

    [SerializeField] private AudioSource audioSource;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BGMPlay()
    {
        // オーディオを再生します
        audioSource.Play();
    }

    public void BGMPause()
    {
        // オーディオを再生します
        audioSource.Pause();
    }

    public void BGMStop()
    {
        // オーディオを再生します
        audioSource.Stop();
    }

    public void SetPitch(float pitchNum)
    {
        audioSource.pitch = pitchNum;
    }

    public void SetVolume(float volumeNum)
    {
        audioSource.volume = volumeNum;
    }


}
