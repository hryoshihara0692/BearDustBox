using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public float speed = 5f;

    private float preX;
    private float preY;

    public Transform displayDustBoxes;

    public GameObject instantiateDustBox;

    private int randomNum;
    public GameObject[] dustBoxes;

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
        StartCoroutine("InstantiateToReady");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextDustBox()
    {
        foreach (Transform dustBox in displayDustBoxes)
        {
            preX = dustBox.position.x;
            preY = dustBox.position.y;

            //右側のいずれかだったら
            if (preX > 0)
            {
                //左に行って”下がる”
                dustBox.position = new Vector3(preX - 0.9f, preY - 0.1f, 0);

                //1つ右が真ん中に来たとき
                if(preX == 0.9f)
                {
                    //どのゴミ箱かを保持する
                    AttackController.instance.SetDustBox(dustBox.name);
                }
            }
            //真ん中もしくは左側のいずれかだったら
            else
            {
                //左に行って”上がる”
                dustBox.position = new Vector3(preX - 0.9f, preY + 0.1f, 0);
            }
        }

        //ゴミ箱の中からどれを出すか
        randomNum = Random.Range(0, dustBoxes.Length);

        //一番右に新規ゴミ箱生成
        Instantiate(dustBoxes[randomNum], new Vector3(1.8f, 0.2f, 0), Quaternion.identity, displayDustBoxes);

    }

    private IEnumerator InstantiateToReady()
    {
        NextDustBox();

        // 1秒待つ  
        yield return new WaitForSeconds(0.5f);

        NextDustBox();

        // 2秒待つ  
        yield return new WaitForSeconds(0.5f);

        NextDustBox();
    }



}
