using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleHouse0 : MonoBehaviour
{
    private int lastplay,newmovie;
    public bool Title;
    public bool stage4;
    public bool stage5;
    [SerializeField] private Animator stage4anim_tobira;
    [SerializeField] private Animator stage4anim_tobira_ue;
    [SerializeField] private Animator stage4anim_tobira_sita;
    [SerializeField] private Animator stage4anim_tobira_temae;
    [SerializeField] private Animator stage4anim_kamera;
    [SerializeField] private Animator stage5anim_pod;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        newmovie = PlayerPrefs.GetInt("movie" + lastplay, 0);
        lastplay = PlayerPrefs.GetInt("StagePlay", 1);
        if (Title == true)
        {
            //エンターキーでHouseへ
            if (Input.GetKeyDown(KeyCode.Return))
            {
                DataReset();
                SceneManager.LoadScene("stage0Wold");
            }
        }
        else
        {
            if (stage4 == false && stage5 == false)
            {
                //エンターキーでHouseへ
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    PlayerPrefs.SetInt("movie" + lastplay, 1);
                    SceneManager.LoadScene("stage" + lastplay + "-1");
                }
            }
            else if (stage4 == true)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    stage4anim_tobira.SetBool("PushEnter", true);
                    stage4anim_tobira_ue.SetBool("PushEnter", true);
                    stage4anim_tobira_sita.SetBool("PushEnter", true);
                    stage4anim_tobira_temae.SetBool("PushEnter", true);
                    stage4anim_kamera.SetBool("PushEnter", true);
                    StartCoroutine(houkai());
                }
            }
            else if(stage5 == true)
            {
                if(Input.GetKeyDown(KeyCode.Return))
                {
                    stage5anim_pod.SetBool("PushEnter", true);
                    StartCoroutine(burori());
                }
            }
            IEnumerator houkai()
            {
                yield return new WaitForSeconds(8);
                PlayerPrefs.SetInt("movie" + lastplay, 1);
                SceneManager.LoadScene("stage" + lastplay + "-1");
            }
            IEnumerator burori()
            {
                yield return new WaitForSeconds(5);
                PlayerPrefs.SetInt("movie" + lastplay, 1);
                SceneManager.LoadScene("stage" + lastplay + "-1");
            }
        }
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
        PlayerPrefs.DeleteKey("movie1");
        PlayerPrefs.DeleteKey("movie2");
        PlayerPrefs.DeleteKey("movie3");
        PlayerPrefs.DeleteKey("movie4");
        PlayerPrefs.DeleteKey("movie5");
        PlayerPrefs.DeleteKey("movie6");
    }
}
