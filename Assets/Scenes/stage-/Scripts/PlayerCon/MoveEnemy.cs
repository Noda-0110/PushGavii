using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Materialsで摩擦を０にしてある、RigitbodyのMaterial

//コンポーネントの追加
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class MoveEnemy : MonoBehaviour
{
    public bool Die = false;
    public float speed = 0;
    public float rspeed = 0;
    [SerializeField] private Rigidbody2D rb;

    GameObject Player;
    GaviController Lifescript;
    private bool Engine;

    //反転
    private bool erflg = true;

    //重力反転
    private bool egflg = false;
    private bool egrflg = false;

    void Start()
    {
        Player = GameObject.Find("Chara");
        Lifescript = Player.GetComponent<GaviController>();
        Engine = false;
        //反転をなくす
        erflg = true;
        // 重力反転をなくす
        egflg = false;
        egrflg = false;
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
            if(Die == true)
            {
                speed = 0;
            }
            if (erflg)
            {
                //常に左へ進み続ける、影響受けない、段差止まる
                rb.velocity = new Vector2(speed, rb.velocity.y);
                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }
            if (!erflg)
            {
                //常に左へ進み続ける、影響受けない、段差止まる
                rb.velocity = new Vector2(rspeed, rb.velocity.y);
                // ローカル座標基準で、現在の回転量へ加算する
                this.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            }

            // 元に戻す
            if (!egrflg)
            {
                //常に右へ進み続ける、影響受けない、段差止まる
                rb.velocity = new Vector2(speed, rb.velocity.y);
                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                Physics2D.gravity = new Vector2(0.0f, -9.81f);
                erflg = true;
            }

            // gflgがtrueで、grflgで反対を向く
            if (egflg && egrflg)
            {
                //常に右へ進み続ける、影響受けない、段差止まる
                rb.velocity = new Vector2(speed, rb.velocity.y);
                Physics2D.gravity = new Vector2(0.0f, 9.81f);
                // ローカル座標基準で、現在の回転量へ加算する
                this.transform.rotation = Quaternion.Euler(180.0f, 180.0f, 0.0f);
            }

            // gflgがtrueで、grflgで正面を向く
            if (egflg && !egrflg)
            {
                //常に右へ進み続ける、影響受けない、段差止まる
                rb.velocity = new Vector2(rspeed, rb.velocity.y);
                Physics2D.gravity = new Vector2(0.0f, 9.81f);
                // ローカル座標基準で、現在の回転量へ加算する
                this.transform.rotation = Quaternion.Euler(180.0f, 0.0f, 0.0f);
            }
            // gflgがtrueで、grflgで正面を向く
            if (!egflg && egrflg)
            {
                //常に右へ進み続ける、影響受けない、段差止まる
                rb.velocity = new Vector2(speed, rb.velocity.y);
                Physics2D.gravity = new Vector2(0.0f, -9.81f);
                // ローカル座標基準で、現在の回転量へ加算する
                this.transform.rotation = Quaternion.Euler(0f, 180.0f, 0.0f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Reverse")
        {
            erflg = true;
            egrflg = true;
        }

        if (coll.gameObject.tag == "RReverse")
        {
            erflg = false;
            egrflg = false;
        }

        if (coll.gameObject.tag == "Gravity")
        {
            //向き　重力　反転せず
            if (egflg == false && egrflg == false)
            {
                egflg = true;
                egrflg = true;
            }
            //向きだけ反転
            else if (egflg == false && egrflg == true)
            {
                egflg = true;
                egrflg = false;
            }
            //重力だけ反転
            else if (egflg == true && egrflg == false)
            {
                egflg = false;
                egrflg = true;
            }
            //向き　重力　反転
            else if (egflg == true && egrflg == true)
            {
                egflg = false;
                egrflg = false;
            }
        }

        if (coll.gameObject.tag == "rGravity")
        {
            egflg = true;
            egrflg = false;
        }

    }
}

        
