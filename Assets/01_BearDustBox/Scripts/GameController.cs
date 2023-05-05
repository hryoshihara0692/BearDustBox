using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float speed = 5f;

    public Transform dustBoxes;

    public GameObject instantiateDustBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0)) {
            foreach(Transform dustBox in dustBoxes)
            {
                //右側のいずれかだったら＝左に行って”下がる”
                if (dustBox.position.x > 0)
                {
                    dustBox.position = new Vector3(dustBox.position.x - 0.9f, dustBox.position.y - 0.1f, 0);
                }
                //真ん中より左だったら＝左に行って”上がる”
                else
                {
                    dustBox.position = new Vector3(dustBox.position.x - 0.9f, dustBox.position.y + 0.1f, 0);
                }
                
            }
            //一番右に新規ゴミ箱生成
            Instantiate(instantiateDustBox, new Vector3(1.8f, 0.2f, 0), Quaternion.identity, dustBoxes);
        }
    }

    
}
