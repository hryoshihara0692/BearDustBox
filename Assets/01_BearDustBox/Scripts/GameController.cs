using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameController : MonoBehaviour
{
    //public static GameController instance;

    private static GameController instance;

    public static GameController Instance
    {
        get { return instance; }
    }

    private int maru = 0;
    private int batsu = 0;
    private int emptyDustBox = 0;
    private int fullDustBox = 0;
    private int bearDustBox = 0;
    private int bombDustBox = 0;
    private int notMissCnt = 0;

    public float speed = 5f;

    //移動前のX座標
    private float preX;
    //移動前のY座標
    private float preY;

    //現在表示しているゴミ箱リスト
    public Transform displayDustBoxes;

    private int randomNum;
    public GameObject[] dustBoxes;

    private Vector3 right3 = new Vector3(2.45f, 0.3f, 1);
    private Vector3 right2 = new Vector3(1.8f, 0.2f, 1);
    private Vector3 right1 = new Vector3(1, 0.1f, 1);
    private Vector3 center = new Vector3(0, 0, 0);
    private Vector3 left1 = new Vector3(-1, 0.1f, 1);
    private Vector3 left2 = new Vector3(-1.8f, 0.2f, 1);
    private Vector3 left3 = new Vector3(-2.45f, 0.3f, 1);

    //private float moveSpeed = 0.5f;

    private bool movingFlag = false;

    public Button openButton;
    public Button closeButton;
    public Button kickButton;
    public Button pickUpButton;

    private AudioSource audioSource;
    public AudioClip countdown;

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
        //Debug.Log("始まってるのかい");
        audioSource = gameObject.GetComponent<AudioSource>();
        StartCoroutine("InstantiateToReady");
    }

    // Update is called once per frame
    void Update()
    {

    }

    //起動時にInstantiateToReady()より3回実行
    //次のゴミ箱に移動する
    public void NextDustBox(float moveSpeed)
    {
        if (!movingFlag)
        {
            movingFlag = true;

            //現在表示しているゴミ箱リストから、1つずつゴミ箱を取り出す
            foreach (Transform dustBox in displayDustBoxes)
            {
                //移動する前のX座標を格納する
                preX = dustBox.position.x;
                //移動する前のY座標を格納する
                preY = dustBox.position.y;

                //Debug.Log(preX);

                //右3だったら
                if (preX == 2.45f)
                {
                    dustBox.DOMove(right2, moveSpeed);
                    dustBox.localScale = new Vector3(dustBox.localScale.x + 0.5f, dustBox.localScale.y + 0.5f, 1);
                }
                //右2だったら
                else if (preX == 1.8f)
                //if (preX == 1.8f)
                {
                    dustBox.DOMove(right1, moveSpeed);
                    dustBox.localScale = new Vector3(dustBox.localScale.x + 0.5f, dustBox.localScale.y + 0.5f, 1);
                }
                //右1だったら
                else if (preX == 1)
                {
                    dustBox.DOMove(center, moveSpeed);
                    dustBox.localScale = new Vector3(dustBox.localScale.x + 0.5f, dustBox.localScale.y + 0.5f, 1);

                    //どのゴミ箱かを保持する（＋コマンドチェック用の配列準備）
                    AttackController.Instance.SetDustBox(dustBox.name);

                    //ゴミ箱の名前をCenterDustBoxに変更する
                    dustBox.name = "CenterDustBox";
                }
                //真ん中だったら
                else if (preX == 0)
                {
                    //ゴミ箱の名前を変更
                    dustBox.name = "LeftDustBox" + preX.ToString();

                    dustBox.DOMove(left1, moveSpeed);
                    dustBox.localScale = new Vector3(dustBox.localScale.x - 0.5f, dustBox.localScale.y - 0.5f, 1);
                }
                //左1だったら
                else if (preX == -1)
                {
                    //ゴミ箱の名前を変更
                    dustBox.name = "LeftDustBox" + preX.ToString();

                    dustBox.DOMove(left2, moveSpeed);
                    dustBox.localScale = new Vector3(dustBox.localScale.x - 0.5f, dustBox.localScale.y - 0.5f, 1);
                }
                //左2だったら
                else if (preX == -1.8f)
                {
                    //ゴミ箱の名前を変更
                    dustBox.name = "LeftDustBox" + preX.ToString();

                    dustBox.DOMove(left3, moveSpeed);
                    dustBox.localScale = new Vector3(dustBox.localScale.x - 0.5f, dustBox.localScale.y - 0.5f, 1);
                }



                ////右側のいずれかだったら
                //if (preX > 0)
                //{

                //    //Debug.Log(dustBox.name);
                //    //左に行って”下がる”
                //    //dustBox.position = new Vector3(preX - 0.9f, preY - 0.1f, 0);
                //    dustBox.DOMove(new Vector3(preX - 0.9f, preY - 0.1f, 0), 0.5f);
                //    dustBox.localScale = new Vector3(dustBox.localScale.x + 0.25f, dustBox.localScale.y + 0.25f, 1);

                //    //1つ右が真ん中に来たとき
                //    if (preX == 0.9f)
                //    {
                //        //どのゴミ箱かを保持する（＋コマンドチェック用の配列準備）
                //        AttackController.instance.SetDustBox(dustBox.name);

                //        //ゴミ箱の名前をCenterDustBoxに変更する
                //        dustBox.name = "CenterDustBox";
                //    }
                //}
                ////真ん中もしくは左側のいずれかだったら
                //else
                //{
                //    //ゴミ箱の名前を変更
                //    dustBox.name = "LeftDustBox" + preX.ToString();

                //    //左に行って”上がる”
                //    //dustBox.position = new Vector3(preX - 0.9f, preY + 0.1f, 0);
                //    dustBox.DOMove(new Vector3(preX - 0.9f, preY + 0.1f, 0), 0.5f);
                //    dustBox.localScale = new Vector3(dustBox.localScale.x - 0.25f, dustBox.localScale.y - 0.25f, 1);

                //}
            }

            //ゴミ箱の中からどれを出すか
            randomNum = Random.Range(0, dustBoxes.Length);

            //一番右に新規ゴミ箱生成
            //Instantiate(dustBoxes[randomNum], new Vector3(1.8f, 0.2f, 0), Quaternion.identity, displayDustBoxes);
            GameObject newDustBox = Instantiate(dustBoxes[randomNum], new Vector3(2.45f, 0.3f, 0), Quaternion.identity, displayDustBoxes);
            newDustBox.name = dustBoxes[randomNum].name;

            movingFlag = false;
        }

    }

    private IEnumerator InstantiateToReady()
    {
        //Debug.Log("始まってるかどうか");

        openButton.interactable = false;
        closeButton.interactable = false;
        kickButton.interactable = false;
        pickUpButton.interactable = false;
        NextDustBox(0.5f);

        yield return new WaitForSeconds(0.5f);

        audioSource.Play();
        UIController.Instance.three.SetActive(true);

        NextDustBox(0.5f);

        yield return new WaitForSeconds(1.0f);

        audioSource.Play();
        UIController.Instance.three.SetActive(false);
        UIController.Instance.two.SetActive(true);

        NextDustBox(0.5f);

        yield return new WaitForSeconds(1.0f);

        audioSource.Play();
        UIController.Instance.two.SetActive(false);
        UIController.Instance.one.SetActive(true);

        NextDustBox(0.5f);

        yield return new WaitForSeconds(1.0f);

        UIController.Instance.one.SetActive(false);
        UIController.Instance.startText.SetActive(true);

        yield return new WaitForSeconds(1.0f);

        UIController.Instance.startText.SetActive(false);
        UIController.Instance.startFlag = true;

        openButton.interactable = true;
        closeButton.interactable = true;
        kickButton.interactable = true;
        pickUpButton.interactable = true;

        BGMController.Instance.BGMPlay();
    }

    public void addMaru(int num)
    {
        maru = maru + num;
    }

    public int getMaru()
    {
        return maru;
    }

    public void addBatsu(int num)
    {
        batsu = batsu + num;
    }

    public int getBatsu()
    {
        return batsu;
    }

    public void addEmptyDustBox(int num)
    {
        emptyDustBox = emptyDustBox + num;
    }

    public int getEmptyDustBox()
    {
        return emptyDustBox;
    }

    public void addFullDustBox(int num)
    {
        fullDustBox = fullDustBox + num;
    }

    public int getFullDustBox()
    {
        return fullDustBox;
    }

    public void addBearDustBox(int num)
    {
        bearDustBox = bearDustBox + num;
    }

    public int getBearDustBox()
    {
        return bearDustBox;
    }

    public void addBombDustBox(int num)
    {
        bombDustBox = bombDustBox + num;
    }

    public int getBombDustBox()
    {
        return bombDustBox;
    }

    public void addNotMissCnt(int num)
    {
        notMissCnt = notMissCnt + num;
    }

    public void clearNotMissCnt()
    {
        notMissCnt = 0;
    }

    public int getNotMissCnt()
    {
        return notMissCnt;
    }
}
