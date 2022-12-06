using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Woldselect : MonoBehaviour
{
    public static Stageselect instance;

    public GameObject Player;   //プレイヤーの位置
    public GameObject[] Worp;   //ワープ先の位置
    public GameObject[] WorpLock;   //ワープ先の位置
    private int now = 0;        //現在のステージ
    private int Stagelength;         //ステージの大きさの器
    private int lastplay;

    

    public int clearwold;  //クリアしたステージ

    [SerializeField] private Animator Worpanimator;
    AudioSource audioSource;
    public AudioClip selectsound;
    public AudioClip worpsound;

    void Start()
    {

        audioSource = GetComponent<AudioSource>();

        lastplay = PlayerPrefs.GetInt("StagePlay", 1);
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
            audioSource.PlayOneShot(selectsound);
            //ステージの数より先には進まない
            if (Stagelength > now && now < clearwold)
            {
                now++;
                Player.transform.position = Worp[now].transform.position;
            }
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            audioSource.PlayOneShot(selectsound);
            //０よりも前に戻らない
            if (0 < now)
            {
                now--;
                Player.transform.position = Worp[now].transform.position;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            audioSource.PlayOneShot(worpsound);
            StartCoroutine(WorpAnim());
        }
        IEnumerator WorpAnim()
        {
            Worpanimator.SetBool("StageBack", true);
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("stage" + now);
        }

        if(clearwold == 1)
        {
            WorpLock[0].SetActive(false);
        }
        if(clearwold >= 2)
        {
            WorpLock[1].SetActive(false);
            WorpLock[0].SetActive(false);
        }
        if(clearwold >= 3)
        {
            WorpLock[1].SetActive(false);
            WorpLock[2].SetActive(false);
            WorpLock[0].SetActive(false);
        }
        if(clearwold >= 4)
        {
            WorpLock[1].SetActive(false);
            WorpLock[2].SetActive(false);
            WorpLock[3].SetActive(false);
            WorpLock[0].SetActive(false);
        }
        if(clearwold >= 5)
        {
            WorpLock[1].SetActive(false);
            WorpLock[2].SetActive(false);
            WorpLock[3].SetActive(false);
            WorpLock[4].SetActive(false);
            WorpLock[0].SetActive(false);
        }

        Debug.Log(now);
        Debug.Log("現在のクリアしたワールドは" + clearwold + "まで");
    }



    public void DataReset()
    {
        //クリア状況のリセット
        PlayerPrefs.DeleteKey("StagePlay");
        PlayerPrefs.DeleteKey("WoldClear");
        PlayerPrefs.DeleteKey("StageClear1");
        PlayerPrefs.DeleteKey("StageClear2");
        PlayerPrefs.DeleteKey("StageClear3");
        PlayerPrefs.DeleteKey("StageClear4");
        PlayerPrefs.DeleteKey("StageClear5");
        PlayerPrefs.DeleteKey("StageClear6");
    }
    public void DataCLEAR()
    {
        //クリアしたことにする
        PlayerPrefs.DeleteKey("StagePlay");
        PlayerPrefs.SetInt("WoldClear", 6);
        PlayerPrefs.SetInt("StageClear1", 6);
        PlayerPrefs.SetInt("StageClear2", 6);
        PlayerPrefs.SetInt("StageClear3", 6);
        PlayerPrefs.SetInt("StageClear4", 6);
        PlayerPrefs.SetInt("StageClear5", 6);
        PlayerPrefs.SetInt("StageClear6", 6);
    }

}
