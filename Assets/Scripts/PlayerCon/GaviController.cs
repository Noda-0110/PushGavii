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
    [Header("現在のステージ(クリア状況更新用)")]
    public int nowstage;
    [Header("体力")]
    public int heart;
    [Header("動くスピード")]
    public float speed = 0;
    [Header("ジャンプの高さ")]
    public float jump = 0;
    [Header("ジャンプ回数")]
    public int JampEne = 3;
    //ジャンプの最大回数を入れる器
    private int JampMax;
    [Header("プレイヤーの特性(バウンドとか)")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    private GameObject Player;
    private GameObject Worp;
    [Header("ヘルプのオブジェクト")]
    public GameObject Help;
    [Header("敵の位置")]
    public GameObject Enemy;
    [Header("敵の出現先の位置")]
    public GameObject EnemyWorp;

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
    }
    void Update()
    {
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
            animator.SetBool("Engine", true);
        }
        //エンジンを付けたら
        if (Engine == true)
        {
            backbutton.SetActive(false);
            //地面との設置状況を受け取る
            isGroundAll = GroundCheck();
            //常に右へ進み続ける、影響受けない、段差止まる
            rb.velocity = new Vector2(speed, rb.velocity.y);
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


    //何かに入った
    private void OnTriggerEnter2D(Collider2D coll)
    {
        Lifelength = LifeCount.Length - 1;
        if (coll.gameObject.tag == "Enemy")
        {
            //ライフを減らす
            heart--;
            Reset();
            Jumpheel();
            restart = true;
            //プライヤーをワープ先に移動
            Player.transform.position = Worp.transform.position;
            Enemy.transform.position = EnemyWorp.transform.position;
        }

        if (coll.gameObject.tag == "Help")
        {
            Help.SetActive(true);
            Engine = false;
        }

        if (coll.gameObject.tag == "Goal")
        {
            //クリアステージの更新、選択画面へ
            PlayerPrefs.SetInt("StageClear", nowstage + 1);
            SceneManager.LoadScene("stage" + nowstage);
        }
        //地面との設置を送る
        if (coll.gameObject.tag == "ground")
        {
            isGroundEnter = true;
        }
    }
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
        if (coll.gameObject.tag == "ground")
        {
            isGroundExit = true;
        }
    }

    public void StageBack()
    {
        SceneManager.LoadScene("stage" + nowstage);
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