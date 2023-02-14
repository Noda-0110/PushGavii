using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class MoveBossEnemy : MonoBehaviour
{
    public bool Die = false;
    private float speed = -50;
    private float rspeed = 50;
    private float grspeed = 50;
    [SerializeField] private Rigidbody2D rb;

    GameObject Player;
    GaviController Lifescript;
    private bool Engine;

    //反転
    private bool rflg = true;

    //重力反転
    private bool gflg = false; // 重力反転していない状態
    private bool grflg = false;// 重力反転中に向きを反転

    void Start()
    {
        Player = GameObject.Find("Chara");
        Lifescript = Player.GetComponent<GaviController>();
        Engine = false;
    }

    void Update()
    {
        Die = Lifescript.GDie;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Engine = true;
        }
        if (Engine == true)
        {
            if (Die == true)
            {
                speed = 0;
            }
            if (rflg)
            {
                //常に右へ進み続ける、影響受けない、段差止まる
                rb.velocity = new Vector2(speed, rb.velocity.y);
                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }
            if (!rflg)
            {
                //常に左へ進み続ける、影響受けない、段差止まる
                rb.velocity = new Vector2(rspeed, rb.velocity.y);
                // ローカル座標基準で、現在の回転量へ加算する
                this.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                Debug.Log("反転しました");
            }

            // gflgがtrueで、grflgで反対を向く
            if (gflg && grflg)
            {
                //常に右へ進み続ける、影響受けない、段差止まる
                rb.velocity = new Vector2(grspeed, rb.velocity.y);
                Physics2D.gravity = new Vector3(0.0f, 9.81f, 0.0f);
                // ローカル座標基準で、現在の回転量へ加算する
                this.transform.rotation = Quaternion.Euler(180.0f, 180.0f, 0.0f);
                Debug.Log("重力を反転して進行方向を反転しました1");
            }

            // gflgがtrueで、grflgで正面を向く
            if (gflg && !grflg)
            {
                //常に右へ進み続ける、影響受けない、段差止まる
                rb.velocity = new Vector2(speed, rb.velocity.y);
                Physics2D.gravity = new Vector3(0.0f, 9.81f, 0.0f);
                // ローカル座標基準で、現在の回転量へ加算する
                this.transform.rotation = Quaternion.Euler(180.0f, 0.0f, 0.0f);
                Debug.Log("重力反転状態のまま進行方向を元に戻しました");
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
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
            //向き　重力　反転せず
            if (gflg == true && grflg == true)
            {
                gflg = true;
                grflg = false;
            }
        }

        if (coll.gameObject.tag == "rGravity")
        {
            // 最初に合ったった場合　重力と反転がfalseだった場合
            if (gflg == false && grflg == false)
            {
                // すべてをtrueにする
                gflg = true;
                grflg = true;
            }

            // 重力はそのままで元の進行方向で返ってきた場合
            if (gflg == true && grflg == false)
            {
                // すべてをtrueにする
                grflg = true;
            }
        }
    }
}
