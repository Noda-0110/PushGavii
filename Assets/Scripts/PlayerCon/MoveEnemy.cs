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
            //��ɓ���������A�e���󂯂Ȃ��A�i���~�܂�
            rb.velocity = new Vector2(speed, rb.velocity.y);

        }
    }

}
