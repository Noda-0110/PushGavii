using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour
{
    public int heart;             //体力
    private GameObject Player;     //プレイヤーの位置
    private GameObject Worp;       //ワープ先の位置
    public GameObject Enemy;       //敵の位置
    public GameObject EnemyWorp;  //敵の出現先の位置
    //public GameObject Life; //文字でLifeを表示する場合に使用

    public GameObject[] LifeCount;
    private int Lifelength;
    private int Gimlength;

    //ギミックの初期化を行う
    //private WSstageMove WSreset;
    //private ADstageMove ADreset;
    //private RotastageMove Roreset;
    //プレイヤーを所得(未使用)
    //public MoveGabi playerreset;

    public bool restart = false;

    void Start()
    {
        Player = GameObject.Find("Chara");
        Worp = GameObject.Find("Worp");
        //ギミックの初期化のために取得
        //WSreset = GameObject.Find("WSbar").gameObject.GetComponent<WSstageMove>();
        //ADreset = GameObject.Find("ADbar").gameObject.GetComponent<ADstageMove>();
        //Roreset = GameObject.Find("Robar").gameObject.GetComponent<RotastageMove>();
        ////プレイヤーを所得(未使用)
        //playerreset = GameObject.Find("Chara").gameObject.GetComponent<MoveGabi>();
        //LifeCount[heart].SetActive(true);
    }

    void Update()
    {

        
        LifeCount[heart].SetActive(true);
        //文字でライフを表示する際に使用
        //Text life_text = Life.GetComponent<Text>();
        //life_text.text = "Life"+heart;

        //ライフが０になったらゲームオーバーへ
        if (heart == 0)
        {
            SceneManager.LoadScene("OverScene");
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        Lifelength = LifeCount.Length - 1;
        if (coll.gameObject.tag == "Enemy")
        {
            //ライフを減らす
            heart--;
            Reset();
            //trueでギミックを初期化
            //WSreset.restart = true;
            //ADreset.restart = true;
            //Roreset.restart = true;

            restart = true;
            //プライヤーをワープ先に移動
            Player.transform.position = Worp.transform.position;
            Enemy.transform.position = EnemyWorp.transform.position;
            if (restart == true)
            {
                restart = false;
            }

        }
    }

    public void Reset()
    {
        for (int i = 0; i <= Lifelength; i++)
        {
            LifeCount[i].SetActive(false);
        }
    }
}
