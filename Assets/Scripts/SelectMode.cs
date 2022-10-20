using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMode : MonoBehaviour
{
    public static Stageselect instance;

    public GameObject Player;   //プレイヤーの位置
    public GameObject[] Worp;   //ワープ先の位置
    private int now = 0;        //現在のステージ
    private int Stagelength;         //ステージの大きさの器


    void Start()
    {

    }

    void Update()
    {
        //最初はWorp[0]の位置にガービィを置く

        //ステージ数取得
        Stagelength = Worp.Length-1;

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //ステージの数より先には進まない
            if (Stagelength > now)
            {
                now++;
                Player.transform.position = Worp[now].transform.position;
            }
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
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
            if(now==0)
            {
                SceneManager.LoadScene("stage0Wold");

            }
            if(now==1)
            {
                SceneManager.LoadScene("tutorial");
            }
            if(now==2)
            {
                SceneManager.LoadScene("Stage");
            }
            if(now==3)
            {
                SceneManager.LoadScene("Stage");
            }
        }

        Debug.Log(now);
    }

}
