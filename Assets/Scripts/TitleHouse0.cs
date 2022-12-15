using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleHouse0 : MonoBehaviour
{
    private int lastplay,newmovie;
    public bool Title;
    public bool stage4;
    [SerializeField] private Animator stage4anim_tobira;
    [SerializeField] private Animator stage4anim_tobira_ue;
    [SerializeField] private Animator stage4anim_tobira_sita;
    [SerializeField] private Animator stage4anim_tobira_temae;
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
                SceneManager.LoadScene("stage0Wold");
            }
        }
        else
        {
            if (stage4 == false)
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
                    StartCoroutine(houkai());
                }
            }
            IEnumerator houkai()
            {
                yield return new WaitForSeconds(8);
                PlayerPrefs.SetInt("movie" + lastplay, 1);
                SceneManager.LoadScene("stage" + lastplay + "-1");
            }
        }
    }
}
