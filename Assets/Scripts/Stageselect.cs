using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stageselect : MonoBehaviour
{
    public static Stageselect instance;
    [Header("現在のクリアしたステージ")]
    public int clearstage1;  //クリアしたステージ
    public int clearstage2;  //クリアしたステージ
    public int clearstage3;  //クリアしたステージ
    public int clearstage4;  //クリアしたステージ
    public int clearstage5;  //クリアしたステージ
    public int clearstage6;  //クリアしたステージ
    public GameObject Player;   //プレイヤーの位置
    public GameObject[] Worp;   //ワープ先の位置
    [Header("ステージ１の旗")]
    public GameObject[] WorpLock1;   //旗を入れる
    [Header("ステージ２の旗")]
    public GameObject[] WorpLock2;   //旗を入れる
    [Header("ステージ３の旗")]
    public GameObject[] WorpLock3;   //旗を入れる
    [Header("ステージ４の旗")]
    public GameObject[] WorpLock4;   //旗を入れる
    [Header("ステージ５の旗")]
    public GameObject[] WorpLock5;   //旗を入れる
    [Header("ステージ６の旗")]
    public GameObject[] WorpLock6;   //旗を入れる
    private int nowStage = 0;        //現在のステージ
    private int Stagelength;         //ステージの大きさの器
    [Header("現在のワールドの数字を入力")]
    public int nowWold = 0;        //現在のワールド

    [SerializeField] private Animator Worpanimator;
    public AudioClip worpsound;
    AudioSource audioSource;
    public AudioClip selectsound;
    AudioSource audioSource2;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource2 = GetComponent<AudioSource>();
    }

    void Update()
    {
        //最後に遊んだステージを入れる
        PlayerPrefs.SetInt("StagePlay", nowWold);

        //Worp[1]までは選択可能
        for (int a = 0; a >= 5; a++) {
        }
        //最初はWorp[0]の位置にガービィを置く

        //ステージ数取得
        Stagelength = Worp.Length - 1;
        if (nowWold == 1)
        {
            clearstage1 = PlayerPrefs.GetInt("StageClear" + 1, 1);
            clearflag(1,clearstage1);
            stagemove(1);
        }
        if (nowWold == 2)
        {
            clearstage2 = PlayerPrefs.GetInt("StageClear" + 2, 1);
            clearflag(2, clearstage2);
            stagemove(2);
        }
        if (nowWold == 3)
        {
            clearstage3 = PlayerPrefs.GetInt("StageClear" + 3, 1);
            clearflag(3, clearstage3);
            stagemove(3);
        }
        if (nowWold == 4)
        {
            clearstage4 = PlayerPrefs.GetInt("StageClear" + 4, 1);
            clearflag(4, clearstage4);
            stagemove(4);
        }
        if (nowWold == 5)
        {
            clearstage5 = PlayerPrefs.GetInt("StageClear" + 5, 1);
            clearflag(5, clearstage5);
            stagemove(5);
        }
        if (nowWold == 6)
        {
            clearstage6 = PlayerPrefs.GetInt("StageClear" + 6, 1);
            clearflag(6, clearstage6);
            stagemove(6);
        }

        Debug.Log("現在のワールドは" + nowWold);
        Debug.Log("現在のステージは" + nowStage);
        switch(nowWold){
            case 1:
                Debug.Log("現在のクリアしたステージは" + clearstage1 + "まで");
                break;
            case 2:
                Debug.Log("現在のクリアしたステージは" + clearstage2 + "まで");
                break;
            case 3:
                Debug.Log("現在のクリアしたステージは" + clearstage3 + "まで");
                break;
            case 4:
                Debug.Log("現在のクリアしたステージは" + clearstage4 + "まで");
                break;
            case 5:
                Debug.Log("現在のクリアしたステージは" + clearstage5 + "まで");
                break;
            case 6:
                Debug.Log("現在のクリアしたステージは" + clearstage6 + "まで");
                break;
        }
    }

    public void clearflag(int Nowold,int clsta)
    {
        if(Nowold == 1)
        {
            if(clsta == 2)
            {
                WorpLock1[0].SetActive(true);
            }
            if(clsta == 3)
            {
                WorpLock1[0].SetActive(true);
                WorpLock1[1].SetActive(true);
            }
            if(clsta >= 4)
            {
                WorpLock1[0].SetActive(true);
                WorpLock1[1].SetActive(true);
                WorpLock1[2].SetActive(true);
            }
        }
        if(Nowold == 2)
        {
            if(clsta == 2)
            {
                WorpLock2[0].SetActive(true);
            }
            if(clsta == 3)
            {
                WorpLock2[0].SetActive(true);
                WorpLock2[1].SetActive(true);
            }
            if(clsta >= 4)
            {
                WorpLock2[0].SetActive(true);
                WorpLock2[1].SetActive(true);
                WorpLock2[2].SetActive(true);
            }
        }
        if(Nowold == 3)
        {
            if(clsta == 2)
            {
                WorpLock3[0].SetActive(true);
            }
            if(clsta == 3)
            {
                WorpLock3[0].SetActive(true);
                WorpLock3[1].SetActive(true);
            }
            if(clsta >= 4)
            {
                WorpLock3[0].SetActive(true);
                WorpLock3[1].SetActive(true);
                WorpLock3[2].SetActive(true);
            }
        }
        if(Nowold == 4)
        {
            if(clsta == 2)
            {
                WorpLock4[0].SetActive(true);
            }
            if(clsta == 3)
            {
                WorpLock4[0].SetActive(true);
                WorpLock4[1].SetActive(true);
            }
            if(clsta >= 4)
            {
                WorpLock4[0].SetActive(true);
                WorpLock4[1].SetActive(true);
                WorpLock4[2].SetActive(true);
            }
        }
        if(Nowold == 5)
        {
            if(clsta == 2)
            {
                WorpLock5[0].SetActive(true);
            }
            if (clsta == 3)
            {
                WorpLock5[0].SetActive(true);
                WorpLock5[1].SetActive(true);
            }
            if(clsta >= 4)
            {
                WorpLock5[0].SetActive(true);
                WorpLock5[1].SetActive(true);
                WorpLock5[2].SetActive(true);
            }
        }
    }
    public void stagemove(int Nowold)
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            audioSource.PlayOneShot(selectsound);
            if (Nowold == 1)
            {
                //ステージの数より先には進まない
                if (Stagelength > nowStage && nowStage < clearstage1)
                {
                    nowStage++;
                    Player.transform.position = Worp[nowStage].transform.position;
                }
            }
            if (Nowold == 2)
            {
                //ステージの数より先には進まない
                if (Stagelength > nowStage && nowStage < clearstage2)
                {
                    nowStage++;
                    Player.transform.position = Worp[nowStage].transform.position;
                }
            }
            if (Nowold == 3)
            {
                //ステージの数より先には進まない
                if (Stagelength > nowStage && nowStage < clearstage3)
                {
                    nowStage++;
                    Player.transform.position = Worp[nowStage].transform.position;
                }
            }
            if (Nowold == 4)
            {
                //ステージの数より先には進まない
                if (Stagelength > nowStage && nowStage < clearstage4)
                {
                    nowStage++;
                    Player.transform.position = Worp[nowStage].transform.position;
                }
            }
            if (Nowold == 5)
            {
                //ステージの数より先には進まない
                if (Stagelength > nowStage && nowStage < clearstage5)
                {
                    nowStage++;
                    Player.transform.position = Worp[nowStage].transform.position;
                }
            }
            if (Nowold == 6)
            {
                //ステージの数より先には進まない
                if (Stagelength > nowStage && nowStage < clearstage6)
                {
                    nowStage++;
                    Player.transform.position = Worp[nowStage].transform.position;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            audioSource.PlayOneShot(selectsound);
            //０よりも前に戻らない
            if (0 < nowStage)
            {
                nowStage--;
                Player.transform.position = Worp[nowStage].transform.position;
            }
        }
        //ステージ内へ
        if (nowStage > 0)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                audioSource.PlayOneShot(worpsound);
                StartCoroutine(WorpAnim());
            }
        }
        IEnumerator WorpAnim()
        {
            int newmovie = PlayerPrefs.GetInt("movie" + nowWold, 0);
            Worpanimator.SetBool("StageBack", true);
            yield return new WaitForSeconds(2);
            if (newmovie == 0)
            {
                SceneManager.LoadScene("moviestage" + nowWold);

            }
            else
            {
                SceneManager.LoadScene("stage" + nowWold + "-" + nowStage);
            }
        }
        //ワールドへ戻る
        if (nowStage == 0)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                audioSource.PlayOneShot(worpsound);
                StartCoroutine(WorpAnim2());
            }
        }
        IEnumerator WorpAnim2()
        {
            Worpanimator.SetBool("StageBack", true);
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("stage0Wold");
        }
    }
}
