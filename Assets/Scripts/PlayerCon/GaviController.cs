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
    public bool KeyConMode = false;
    [Header("現在のワールド(クリア状況更新用)")]
    public int nowwold;
    [Header("現在のステージ(クリア状況更新用)")]
    public int nowstage;
    [Header("体力")]
    public int heart;
    //[Header("動くスピード")]
    private float speed = 4f;
    private float rspeed = -4f;
    private float grspeed = -4f;
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
    [Header("ステージ0でキャンバス")]
    public GameObject canobj;

    [Header("メインカメラ")]
    public Camera Camera;
    [Header("サブカメラ")]
    public Camera subCamera;

    //キャンバス
    private GameObject Canvas;

    Animator StageAnimator;

    //カメラ使用時のガービィの操作を制限するやつ
    private bool cammode = false;

    //サブカメラの場合のみ非表示
    private GameObject dlcv1;
    private GameObject dlcv2;
    private GameObject dlcv3;
    private GameObject dlcv4;
    private GameObject dlcv5;
    private GameObject dlcv6;
    private GameObject dlcv7;

    private GameObject ChangeButton;


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
    private GameObject EnjDrawn;

    //反転
    private bool rflg = true;

    //重力反転
    private bool gflg = false;
    private bool grflg = false;

    [Header("カメラの位置")]
    public float cameraX = 5;

    [Header("ワープ先１ Tag:Worp1")]
    public GameObject Worp1;
    [Header("ワープ先２ Tag:Worp2")]
    public GameObject Worp2;

    [Header("プレイヤーの特性(バウンドとか)")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator Gavianimator;
    [SerializeField] private Animator stage0animator;
    [SerializeField] private Animator Worpanimator;
    [SerializeField] private Animator Dieanimator;

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

    [Header("ガービィの死を管理")]
    public bool GDie = false;

    //やり直し用
    private int lastplay;

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

        //ステージを見る用のアニメーション
        StageAnimator = subCamera.gameObject.GetComponent<Animator>();
        //Canvas内のオブジェクト
        dlcv1 = GameObject.Find("BGMSlider");
        dlcv2 = GameObject.Find("LifeBack");
        dlcv3 = GameObject.Find("JampBack");
        dlcv4 = GameObject.Find("Life");
        dlcv5 = GameObject.Find("BackButton");
        dlcv6 = GameObject.Find("Number-Life");
        dlcv7 = GameObject.Find("Number-Jump");
        Canvas = GameObject.Find("Canvas");
        ChangeButton = GameObject.Find("SubButton");
        //初めはサブカメラをオフにしておく
        subCamera.enabled = false;
        // 重力反転をなくす
        gflg = false;
        grflg = false;
    }
    void Update()
    {
        //ステージ前にも戻る
        lastplay = PlayerPrefs.GetInt("StagePlay", 1);

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
        //Debug.Log(heart);
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
        if (cammode == false)
        {
            //エンターでエンジンを起動
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Engine = true;
                PushEnter.SetActive(false);
                ChangeButton.SetActive(false);
                Gavianimator.SetBool("Engine", true);
            }
        }
        //エンジンを付けたら
        if (Engine == true)
        {
            //backbutton.SetActive(false);
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
                if(!rflg)
                {
                    //常に左へ進み続ける、影響受けない、段差止まる
                    rb.velocity = new Vector2(rspeed, rb.velocity.y);
                    // ローカル座標基準で、現在の回転量へ加算する
                    this.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                    FollowCamera.cameraX = -5;
                }

                // 元に戻す
                if (!grflg)
                {
                    //常に右へ進み続ける、影響受けない、段差止まる
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                    this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                    Physics2D.gravity = new Vector2(0.0f, -9.81f);
                    rflg = true;
                }

                // gflgがtrueで、grflgで反対を向く
                if (gflg && grflg)
                {
                    //常に右へ進み続ける、影響受けない、段差止まる
                    rb.velocity = new Vector2(grspeed, rb.velocity.y);
                    Physics2D.gravity = new Vector2(0.0f, 9.81f);
                    // ローカル座標基準で、現在の回転量へ加算する
                    this.transform.rotation = Quaternion.Euler(180.0f, 180.0f, 0.0f);
                    FollowCamera.cameraX = -5;
                    FollowCamera.cameraY = 0;
                }

                // gflgがtrueで、grflgで正面を向く
                if (gflg && !grflg)
                {
                    //常に右へ進み続ける、影響受けない、段差止まる
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                    Physics2D.gravity = new Vector2(0.0f, 9.81f);
                    // ローカル座標基準で、現在の回転量へ加算する
                    this.transform.rotation = Quaternion.Euler(180.0f, 0.0f, 0.0f);
                    FollowCamera.cameraX = 5;
                    FollowCamera.cameraY = 0;
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
        if(coll.gameObject.tag == "spike")
        {
            heart--;
            Reset();
            //ライフが０になったらゲームオーバーへ
            if (heart == 0)
            {
                GDie = true;
                speed = 0;
                Dieanimator.SetBool("Die", true);
                StartCoroutine(Die());
            }
            IEnumerator Die()
            {
                yield return new WaitForSeconds(5);
                SceneManager.LoadScene("OverScene");
            }
        }
        if (coll.gameObject.tag == "Enemy")
        {
            //ライフを減らす
            heart--;
            Reset();
            Jumpheel();
            restart = true;
            //ライフが０になったらゲームオーバーへ
            if (heart == 0)
            {
                GDie = true;
                speed = 0;
                Dieanimator.SetBool("Die", true);
                StartCoroutine(Die());
            }
            else if (heart >= 1)
            {
                //プライヤーをワープ先に移動
                Player.transform.position = Worp.transform.position;
                // 重力反転をなくす
                gflg = false;
                grflg = false;
            }
            IEnumerator Die()
            {
                yield return new WaitForSeconds(5);
                SceneManager.LoadScene("OverScene");
            }

        }
        if (coll.gameObject.tag == "Reverse")
        {
            rflg = false;
            grflg = true;
        }

        if (coll.gameObject.tag == "RReverse")
        {
            rflg = true;
            grflg = false;
        }

        if (coll.gameObject.tag == "Gravity")
        {
            if (gflg == false)
            {
                gflg = true;
                grflg = true;
            }
            else if(gflg == true)
            {
                gflg = false;
                grflg = false;
            }
        }

        if (coll.gameObject.tag == "rGravity")
        {
            gflg = true;
            grflg = false;
        }
    }

    //何かに入った
    private void OnTriggerEnter2D(Collider2D coll)
    {
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
            PlayerPrefs.SetInt("StageClear"+ nowwold, nowstage + 1);
            Gavianimator.SetBool("Bye", true);
            StartCoroutine(StageCrear());
        }

        if (coll.gameObject.tag == "LastGoal")
        {
            speed = 0;
            rspeed = 0;
            //クリアステージの更新、選択画面へ
            PlayerPrefs.SetInt("StageClear" + nowwold, nowstage + 1);
            //クリアワールドの更新、選択画面へ
            PlayerPrefs.SetInt("WoldClear", CrearWorld + 1);
            Gavianimator.SetBool("Bye", true);
            StartCoroutine(StageCrear());
        }
        //最後のステージのゴール
        if (coll.gameObject.tag == "Goal0")
        {
            speed = 0;
            rspeed = 0;
            canobj.SetActive(false);
            //クリアワールドの更新、選択画面へ
            PlayerPrefs.SetInt("WoldClear", 7);
            Gavianimator.SetBool("Bye", true);
            stage0animator.SetBool("goal0", true);
            StartCoroutine(StageCrear0());
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
        /*
        if (coll.gameObject.tag == "Reverse")
        {
            rflg = false;
        }

        if (coll.gameObject.tag == "RReverse")
        {
            rflg = true;
        }
        */
    }
    IEnumerator StageCrear()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("stage" + CrearWorld);
    }
    IEnumerator StageCrear0()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("stage0Wold");
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

    public void PushButtonCamera()
    {
        //もしサブカメラがオフだったら
        if (!subCamera.enabled)
        {
            //カメラモードオン（操作を制限）
            cammode = true;
            //サブカメラをオンにして
            subCamera.enabled = true;

            //カメラをオフにする
            Camera.enabled = false;

            
            StageAnimator.SetBool("PlayMap",true);


            ChangeButton.GetComponentInChildren<Text>().text = "ステージに戻る";

            //PushEnterを非表示にする
            PushEnter.SetActive(false);

            dlcv1.SetActive(false);
            dlcv2.SetActive(false);
            dlcv3.SetActive(false);
            dlcv4.SetActive(false);
            dlcv5.SetActive(false);
            dlcv6.SetActive(false);
            dlcv7.SetActive(false);

            //キャンバスを映すカメラをサブカメラオブジェクトにする
            Canvas.GetComponent<Canvas>().worldCamera = subCamera;
        }
        //もしサブカメラがオンだったら
        else
        {
            //カメラモードオフ（操作制限解除）  
            cammode = false;
            //サブカメラをオフにして
            subCamera.enabled = false;

            //カメラをオンにする
            Camera.enabled = true;


            StageAnimator.SetBool("PlayMap", false);


            ChangeButton.GetComponentInChildren<Text>().text = "ステージを見る";

            //PushEnterを表示する
            PushEnter.SetActive(true);

            dlcv1.SetActive(true);
            dlcv2.SetActive(true);
            dlcv3.SetActive(true);
            dlcv4.SetActive(true);
            dlcv5.SetActive(true);
            dlcv6.SetActive(true);
            dlcv7.SetActive(true);

            //キャンバスを映すカメラをカメラオブジェクトにする
            Canvas.GetComponent<Canvas>().worldCamera = Camera;
        }
    }
}