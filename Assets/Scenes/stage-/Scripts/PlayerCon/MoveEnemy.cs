using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Materials�Ŗ��C���O�ɂ��Ă���ARigitbody��Material

//�R���|�[�l���g�̒ǉ�
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class MoveEnemy : MonoBehaviour
{
    public bool Die = false;
    public float speed = 0;
    public float rspeed = 0;
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
            //��ɍ��֐i�ݑ�����A�e���󂯂Ȃ��A�i���~�܂�
            rb.velocity = new Vector2(speed, rb.velocity.y);
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            
        }
    }
}

        
