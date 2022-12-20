using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saisyono : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        
    }

}
