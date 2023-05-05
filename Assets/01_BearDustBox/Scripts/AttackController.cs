using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public static AttackController instance;

    public string dustBoxName;

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
        //Debug.Log(dustBoxName);
    }

    //public void Hello()
    //{
    //    Debug.Log("Hello");
    //}

    public void SetDustBoxName(string dustBoxName)
    {
        this.dustBoxName = dustBoxName;

        Debug.Log(dustBoxName);
    }
}
