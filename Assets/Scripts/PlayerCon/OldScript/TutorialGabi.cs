using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Materialsで摩擦を０にしてある、RigitbodyのMaterial

//コンポーネントの追加
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class TutorialGabi : MonoBehaviour
{
    public float speed = 0;
    public float jump = 0;
    [SerializeField] private Rigidbody2D rb;

    //接地判定と移動可能か
    private bool isGroundEnter, isGroundStay, isGroundExit, isGroundCheck, isGroundAll;
    public GameObject[] JampCount;
    public int JampEne = 3;
    private int JampMax;



    void Start()
    {
        //ジャンプの最大回数を取得
        JampMax = JampEne;
        isGroundAll = false;

    }

    void Update()
    {
        //残りジャンプ回数を表示
        JampCount[JampEne].SetActive(true);

        //地面との設置状況を受け取る
        isGroundAll = GroundCheck();
        //常に右へ進み続ける、影響受けない、段差止まる
        rb.velocity = new Vector2(speed, rb.velocity.y);
        //接地していればジャンプ可能
        if (Input.GetKeyDown(KeyCode.C)&& isGroundAll == true && JampEne > 0)
        {
            JampEne--;
            Jump();//ジャンプする
        }        //接地していればジャンプ可能
        if (Input.GetKeyDown(KeyCode.M)&& isGroundAll == true && JampEne > 0)
        {
            JampEne--;
            Jump();//ジャンプする
        }
    }

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
        if (coll.gameObject.tag == "Goal")
        {
            //クリアステージの更新、選択画面へ
            PlayerPrefs.SetInt("Clear", 2);
            SceneManager.LoadScene("stage0Wold");
        }
        //地面との設置を送る
        if (coll.gameObject.tag == "ground")
        {
            isGroundEnter = true;
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
        SceneManager.LoadScene("stage0Wold");
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
