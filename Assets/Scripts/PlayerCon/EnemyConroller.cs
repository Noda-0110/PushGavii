using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConroller : MonoBehaviour
{
    [Header("ìGÇÃà íu")]
    public GameObject[] Enemy;
    [Header("ìGÇÃèoåªêÊÇÃà íu")]
    public GameObject[] EnemyWorp;

    private int EnemyLen = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        EnemyLen = Enemy.Length-1;
        if (coll.gameObject.tag == "Enemy")
        {
            for (int a = 0; a <= EnemyLen; a++)
            {
                Enemy[a].transform.position = EnemyWorp[a].transform.position;
            }
        }
    }
}
