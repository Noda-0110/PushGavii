using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Materialsで摩擦を０にしてある、RigitbodyのMaterial

//コンポーネントの追加
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class MoveEnemy : MonoBehaviour
{
    public bool Die = false;
    public float speed = 0;
    [SerializeField] private Rigidbody2D rb;

    GameObject Player;
    GaviController Lifescript;
    private bool Engine;

    void Start()
    {
        Player = GameObject.Find("Chara");
        Lifescript = Player.GetComponent<GaviController>();
        Engine = false;
    }

    void Update()
    {
        Die = Lifescript.GDie;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Engine = true;
        }
        if (Engine == true)
        {
            if(Die == true)
            {
                speed = 0;
            }
            //常に動き続ける、影響受けない、段差止まる
            rb.velocity = new Vector2(speed, rb.velocity.y);

        }
    }

}
