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
    public float speed = 0;
    [SerializeField] private Rigidbody2D rb;

    private bool Engine;

    void Start()
    {
        Engine = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Engine = true;
        }
        if (Engine == true)
        {
            //��ɓ���������A�e���󂯂Ȃ��A�i���~�܂�
            rb.velocity = new Vector2(speed, rb.velocity.y);

        }
    }

}
