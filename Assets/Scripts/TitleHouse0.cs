using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleHouse0 : MonoBehaviour
{
    private int lastplay,newmovie;
    public bool Title;
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
            //エンターキーでHouseへ
            if (Input.GetKeyDown(KeyCode.Return))
            {
                PlayerPrefs.SetInt("movie" + lastplay, 1);
                SceneManager.LoadScene("stage"+lastplay + "-1");
            }
        }
    }
}
