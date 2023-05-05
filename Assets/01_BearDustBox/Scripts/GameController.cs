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
        StartCoroutine("InstantiateToReady");
    }

    // Update is called once per frame
    void Update()
    {
        //一つクリアもしくは失敗したあと
        //※現状はクリックしたら実行
        if (Input.GetMouseButtonUp(0)) {
            setDustBox();
        }
    }

    void setDustBox()
    {
        foreach (Transform dustBox in dustBoxes)
        {
            float preX = dustBox.position.x;
            float preY = dustBox.position.y;

            //右側のいずれかだったら
            if (preX > 0)
            {
                //左に行って”下がる”
                dustBox.position = new Vector3(preX - 0.9f, preY - 0.1f, 0);

                //1つ右が真ん中に来たとき
                if(preX == 0.9f)
                {
                    //どのゴミ箱かを保持する
                    AttackController.instance.SetDustBoxName(dustBox.name);
                }
            }
            //真ん中もしくは左側のいずれかだったら
            else
            {
                //左に行って”上がる”
                dustBox.position = new Vector3(preX - 0.9f, preY + 0.1f, 0);
            }
        }
        //一番右に新規ゴミ箱生成
        Instantiate(instantiateDustBox, new Vector3(1.8f, 0.2f, 0), Quaternion.identity, dustBoxes);

    }

    private IEnumerator InstantiateToReady()
    {
        setDustBox();

        // 1秒待つ  
        yield return new WaitForSeconds(0.5f);

        setDustBox();

        // 2秒待つ  
        yield return new WaitForSeconds(0.5f);

        setDustBox();
    }



}
