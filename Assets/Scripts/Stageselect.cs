using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stageselect : MonoBehaviour
{
    public static Stageselect instance;

    [Header("現在のクリアしたステージ")]
    public int clearstage;  //クリアしたステージ
    public GameObject Player;   //プレイヤーの位置
    public GameObject[] Worp;   //ワープ先の位置
    private int nowStage = 0;        //現在のステージ
    private int Stagelength;         //ステージの大きさの器
    [Header("現在のワールドの数字を入力")]
    public int nowWold = 0;        //現在のワールド


    void Start()
    {
    }

    void Update()
    {
        //最後に遊んだステージ
        PlayerPrefs.SetInt("StagePlay", nowWold);
        //Worp[1]までは選択可能
        clearstage = PlayerPrefs.GetInt("StageClear", 6);
        //最初はWorp[0]の位置にガービィを置く

        //ステージ数取得
        Stagelength = Worp.Length - 1;

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //ステージの数より先には進まない
            if (Stagelength > nowStage && nowStage < clearstage)
            {
                nowStage++;
                Player.transform.position = Worp[nowStage].transform.position;
            }
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //０よりも前に戻らない
            if (0 < nowStage)
            {
                nowStage--;
                Player.transform.position = Worp[nowStage].transform.position;
            }
        }

        if (nowStage > 0)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("stage" + nowWold + "-" + nowStage);
            }
        }
        if (nowStage == 0)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("stage0Wold");
            }
        }

        Debug.Log(nowStage);
        Debug.Log("現在のクリアしたステージは" + clearstage + "まで");
    }

}
