using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stageselect : MonoBehaviour
{
    public static Stageselect instance;

    public GameObject Player;   //プレイヤーの位置
    public GameObject[] Worp;   //ワープ先の位置
    private int now = 0;        //現在のステージ
    private int Stagelength;         //ステージの大きさの器

    public int clearstage;  //クリアしたステージ

    void Start()
    {

    }

    void Update()
    {
        //Worp[1]までは選択可能
        clearstage = PlayerPrefs.GetInt("Clear",1);
        //最初はWorp[0]の位置にガービィを置く

        //ステージ数取得
        Stagelength = Worp.Length-1;

        if (Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.RightArrow))
        {
            //ステージの数より先には進まない
            if (Stagelength > now && now < clearstage)
            {
                now++;
                Player.transform.position = Worp[now].transform.position;
            }
        }
        if (Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //０よりも前に戻らない
            if (0 < now)
            {
                now--;
                Player.transform.position = Worp[now].transform.position;
            }
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("stage" + now);
        }

        Debug.Log(now);
        Debug.Log("現在のクリアしたステージは"+clearstage+"まで");
    }

}
