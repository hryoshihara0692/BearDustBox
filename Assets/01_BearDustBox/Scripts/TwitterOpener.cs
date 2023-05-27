using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwitterOpener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void twitterOpen()
    {
        Application.OpenURL("https://twitter.com/aoyanagi0692");
    }
}
