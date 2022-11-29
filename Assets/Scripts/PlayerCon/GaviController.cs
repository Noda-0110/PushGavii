using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]

public class GaviController : MonoBehaviour
{
    private bool KeyConMode = false;
    [Header("現在のワールド(クリア状況更新用)")]
    public int nowwold;
    [Header("現在のステージ(クリア状況更新用)")]
    public int nowstage;
    [Header("体力")]
    public int heart;
    //[Header("動くスピード")]
    private float speed = 4f;
    private float rspeed = -4f;
    [Header("ジャンプの高さ")]
    public float jump = 0;
    [Header("ジャンプ回数")]
    public int JampEne = 3;
    [Header("ヘルプのオブジェクト1")]
    public GameObject HelpPack1;
    [Header("ヘルプを出すブロック1")]
    public GameObject Help1;
    [Header("ヘルプのオブジェクト2")]
    public GameObject HelpPack2;
    [Header("ヘルプを出すブロック2")]
    public GameObject Help2;

    [Header("ワープ1-1の出口")]
    public float worp1_1_X;
    public float worp1_1_Y;
    [Header("ワープ1-2の出口")]
    public float worp1_2_X;
    public float worp1_2_Y;
    [Header("ワープ2-1の出口")]
    public float worp2_1_X;
    public float worp2_1_Y;
    [Header("ワープ2-2の出口")]
    public float worp2_2_X;
    public float worp2_2_Y;
    [Header("ワープ3-1の出口")]
    public float worp3_1_X;
    public float worp3_1_Y;
    [Header("ワープ3-2の出口")]
    public float worp3_2_X;
    public float worp3_2_Y;

    //ワープ時に使用
    private bool wflg1_1 = false;
    private bool wflg1_2 = false;
    private bool wflg2_1 = false;
    private bool wflg2_2 = false;
    private bool wflg3_1 = false;
    private bool wflg3_2 = false;


    //ジャンプの最大回数を入れる器
    private int JampMax;
    //ワールドクリアに使う
    private int CrearWorld;

    private bool helpmode1 = false;
    private bool helpmode2 = false;

    private GameObject Player;
    private GameObject Worp;
    private GameObject PushEnter;

    //反転
    private bool rflg = true;
    [Header("カメラの位置")]
    public float cameraX = 5;

    [Header("ワープ先１ Tag:Worp1")]
    public GameObject Worp1;
    [Header("ワープ先２ Tag:Worp2")]
    public GameObject Worp2;

    [Header("プレイヤーの特性(バウンドとか)")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator Gavianimator;
    [SerializeField] private Animator Worpanimator;

    //接地判定と移動可能か
    [Header("")]
    private bool isGroundEnter, isGroundStay, isGroundExit, isGroundCheck, isGroundAll;
    [Header("trueで動き出す")]
    public bool Engine;

    [Header("選択画面へ戻るボタン")]
    public GameObject backbutton;
    [Header("ジャンプ回数の数字を入れる配列")]
    public GameObject[] JampCount;
    [Header("残り残機の数字を入れる配列")]
    public GameObject[] LifeCount;
    //体力配列の長さ
    private int Lifelength;

    [Header("リセットを管理")]
    public bool restart = false;

    void Start()
    {
        //ジャンプの最大回数を取得
        JampMax = JampEne;
        //戻るボタンを表示
        backbutton.SetActive(true);
        //エンジンを停止
        Engine = false;
        //設置状況をfalseに
        isGroundAll = false;
        //プレイヤーを取得
        Player = GameObject.Find("Chara");
        //復活位置を取得
        Worp = GameObject.Find("Worp");
        //プッシュエンターを取得
        PushEnter = GameObject.Find("PushEnter");
    }
    void Update()
    {
            //ワープ時に使用
            Vector3 pos = gameObject.transform.position;
        if (wflg1_1)
        {
            pos.x = worp1_1_X;
            pos.y = worp1_1_Y;
            gameObject.transform.position = pos;
        }
        if (wflg1_2)
        {
            pos.x = worp1_2_X;
            pos.y = worp1_2_Y;
            gameObject.transform.position = pos;
        }
        if (wflg2_1)
        {
            pos.x = worp2_1_X;
            pos.y = worp2_1_Y;
            gameObject.transform.position = pos;
        }
        if (wflg2_2)
        {
            pos.x = worp2_2_X;
            pos.y = worp2_2_Y;
            gameObject.transform.position = pos;
        }
        if (wflg3_1)
        {
            pos.x = worp3_1_X;
            pos.y = worp3_1_Y;
            gameObject.transform.position = pos;
        }
        if (wflg3_2)
        {
            pos.x = worp3_2_X;
            pos.y = worp3_2_Y;
            gameObject.transform.position = pos;
        }
        Debug.Log(heart);
        if (helpmode1 == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                HelpPack1.SetActive(false);
                Help1.SetActive(false);
                Time.timeScale = 1;
                helpmode1 = false;
            }
        }
        if (helpmode2 == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                HelpPack2.SetActive(false);
                Help2.SetActive(false);
                Time.timeScale = 1;
                helpmode2 = false;
            }
        }

        //PlayerPrefs.SetInt("WoldClear", 1);
        CrearWorld = PlayerPrefs.GetInt("StagePlay", 1);
        if (restart == true)
        {
            restart = false;
        }
        //残りジャンプ回数を表示
        JampCount[JampEne].SetActive(true);

        //エンターでエンジンを起動
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Engine = true;
            PushEnter.SetActive(false);
            Gavianimator.SetBool("Engine", true);
        }
        //エンジンを付けたら
        if (Engine == true)
        {
            backbutton.SetActive(false);
            //地面との設置状況を受け取る
            isGroundAll = GroundCheck();

            Vector2 keypos = transform.position;
            //ガービィをキー操作できるようにする
            if (KeyConMode)
            {
                float keyspeed = 0.05f;
                float keyjump = 0.05f;
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    keypos.x -= keyspeed;
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    keypos.x += keyspeed;
                }        
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    keypos.y += keyjump;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    keypos.y -= keyjump;
                }
                transform.position = keypos;

            }
            //通常操作
            else
            {
                if (rflg)
                {
                    //常に右へ進み続ける、影響受けない、段差止まる
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                    this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                    FollowCamera.cameraX = 5;
                }
                else
                {
                    //常に左へ進み続ける、影響受けない、段差止まる
                    rb.velocity = new Vector2(rspeed, rb.velocity.y);
                    // ローカル座標基準で、現在の回転量へ加算する
                    this.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                    FollowCamera.cameraX = -5;
                }
                //transform.Translate(transform.right * Time.deltaTime * 3 * speed);
                //接地していればジャンプ可能
                if (Input.GetKeyDown(KeyCode.C) && isGroundAll == true && JampEne > 0)
                {
                    JampEne--;
                    Jump();//ジャンプする
                }        //接地していればジャンプ可能
                if (Input.GetKeyDown(KeyCode.M) && isGroundAll == true && JampEne > 0)
                {
                    JampEne--;
                    Jump();//ジャンプする
                }
            }
        }
        //残機を表示
        LifeCount[heart].SetActive(true);

        //ライフが０になったらゲームオーバーへ
        if (heart == 0)
        {
            SceneManager.LoadScene("OverScene");
        }
    }

    //ジャンプする
    private void Jump()
    {
        for (int i = 0; i <= JampMax; i++)
        {
            JampCount[i].SetActive(false);
        }
        //Forceは継続的に力を加える　Impulseは瞬間的に力を加える
        rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
    }

    //設置状況を調べて渡す
    public bool GroundCheck()
    {
        if (isGroundEnter || isGroundStay)
        {
            isGroundCheck = true;
        }
        else if (isGroundExit)
        {
            isGroundCheck = false;
        }
        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;

        return isGroundCheck;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        Lifelength = LifeCount.Length - 1;

        if (coll.gameObject.tag == "Reverse")
        {
            rflg = false;
        }

        if (coll.gameObject.tag == "RReverse")
        {
            rflg = true;
        }
    }

    //何かに入った
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            //ライフを減らす
            heart--;
            Reset();
            Jumpheel();
            restart = true;
            //プライヤーをワープ先に移動
            Player.transform.position = Worp.transform.position;
        }
        if (coll.gameObject.tag == "Worp1-1")
        {
            wflg1_1 = true;
        }
        if (coll.gameObject.tag == "Worp1-2")
        {
            wflg1_2 = true;
        }
        if (coll.gameObject.tag == "Worp2-1")
        {
            wflg2_1 = true;
        }
        if (coll.gameObject.tag == "Worp2-2")
        {
            wflg2_2 = true;
        }
        if (coll.gameObject.tag == "Worp3-1")
        {
            wflg3_1 = true;
        }
        if (coll.gameObject.tag == "Worp3-2")
        {
            wflg3_2 = true;
        }
        if (coll.gameObject.tag == "Goal")
        {
            speed = 0;
            rspeed = 0;
            //クリアステージの更新、選択画面へ
            PlayerPrefs.SetInt("StageClear"+nowwold, nowstage + 1);
            Gavianimator.SetBool("Bye", true);
            StartCoroutine(StageCrear());
        }

        if (coll.gameObject.tag == "LastGoal")
        {
            speed = 0;
            rspeed = 0;
            //クリアワールドの更新、選択画面へ
            PlayerPrefs.SetInt("WoldClear", CrearWorld + 1);
            Gavianimator.SetBool("Bye", true);
            StartCoroutine(StageCrear());
        }

        //地面との設置を送る
        if (coll.gameObject.tag == "ground")
        {
            isGroundEnter = true;
        }
        //ポップアップを表示１
        if (coll.gameObject.tag == "Help1")
        {
            Engine = false;
            HelpPack1.SetActive(true);
            Time.timeScale = 0;
            helpmode1 = true;
        }
        //ポップアップを表示２
        if (coll.gameObject.tag == "Help2")
        {
            Engine = false;
            HelpPack2.SetActive(true);
            Time.timeScale = 0;
            helpmode2 = true;
        }
    }
    IEnumerator StageCrear()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("stage" + CrearWorld);
    }


    //IEnumerator 
    public void Reset()
    {
        for (int i = 0; i <= Lifelength; i++)
        {
            LifeCount[i].SetActive(false);
        }
    }

    //何かの中にいる
    private void OnTriggerStay2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "ground")
        {
            isGroundStay = true;
        }
    }

    //何かから出た
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Worp1-1")
        {
            wflg1_1 = false;
        }
        if (coll.gameObject.tag == "Worp1-2")
        {
            wflg1_2 = false;
        }
        if (coll.gameObject.tag == "Worp2-1")
        {
            wflg2_1 = false;
        }
        if (coll.gameObject.tag == "Worp2-2")
        {
            wflg2_2 = false;
        }
        if (coll.gameObject.tag == "Worp3-1")
        {
            wflg3_1 = false;
        }
        if (coll.gameObject.tag == "Worp3-2")
        {
            wflg3_2 = false;
        }

        if (coll.gameObject.tag == "ground")
        {
            isGroundExit = true;
        }
    }

    public void StageBack()
    {
        StartCoroutine(WorpAnim());
    }


    IEnumerator WorpAnim()
    {
        Worpanimator.SetBool("StageBack", true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("stage" + CrearWorld);
    }
    public void Jumpheel()
    {
        for (int i = 0; i <= JampMax; i++)
        {
            JampCount[i].SetActive(false);
        }
        JampEne = 3;
    }
}