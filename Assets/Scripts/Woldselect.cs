using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Woldselect : MonoBehaviour
{
    public static Stageselect instance;

    public GameObject Player;   //プレイヤーの位置
    public GameObject[] Worp;   //ワープ先の位置
    private int now = 0;        //現在のステージ
    private int Stagelength;         //ステージの大きさの器
    private int lastplay;

    public int clearwold;  //クリアしたステージ

    void Start()
    {

        lastplay = PlayerPrefs.GetInt("StagePlay", 0);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("stage" + lastplay);
        }
        Player.transform.position = Worp[lastplay].transform.position;
        now = lastplay;
    }

    void Update()
    {
        //stageの最後をクリアするとWoldClearが更新される
        clearwold = PlayerPrefs.GetInt("WoldClear", 1);
        //最初はWorp[0]の位置にガービィを置く

        //ステージ数取得
        Stagelength = Worp.Length - 1;

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //ステージの数より先には進まない
            if (Stagelength > now && now < clearwold)
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

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("stage" + now);
        }

        Debug.Log(now);
        Debug.Log("現在のクリアしたステージは" + clearwold + "まで");
    }

}
