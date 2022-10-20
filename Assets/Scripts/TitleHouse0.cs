using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleHouse0 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //エンターキーでHouseへ
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("House");
        }
    }

    //チュートリアルをスキップ
    public void Stage0Skip()
    {
        SceneManager.LoadScene("stage0Wold");
    }
}
