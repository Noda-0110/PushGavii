using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHelpConroller : MonoBehaviour
{
    [Header("敵の位置")]
    public GameObject[] Enemy;
    [Header("敵の出現先の位置")]
    public GameObject[] EnemyWorp;[Header("ヘルプのオブジェクト")]
    public GameObject Help1;
    //public GameObject Help2;

    private int EnemyLen = 0;
    private bool helpmode = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (helpmode == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Time.timeScale = 1;
                Help1.SetActive(false);
                //Help2.SetActive(false);
                helpmode = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        EnemyLen = Enemy.Length - 1;
        if (coll.gameObject.tag == "Enemy")
        {
            for (int a = 0; a <= EnemyLen; a++)
            {
                Enemy[a].transform.position = EnemyWorp[a].transform.position;
            }
        }
        //ポップアップを表示、未完成
        if (coll.gameObject.tag == "Help1")
        {
            Time.timeScale = 0;
            Help1.SetActive(true);
            helpmode = true;
        }
        /*
        //ポップアップを表示、未完成
        if (coll.gameObject.tag == "Help2")
        {
            Time.timeScale = 0;
            Help2.SetActive(true);
            helpmode = true;
        }
        */

    }
}
