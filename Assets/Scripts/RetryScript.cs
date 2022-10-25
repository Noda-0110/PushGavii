using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryScript : MonoBehaviour
{
    private int lastplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lastplay = PlayerPrefs.GetInt("StagePlay", 1);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("stage"+ lastplay);
        }
    }
}
