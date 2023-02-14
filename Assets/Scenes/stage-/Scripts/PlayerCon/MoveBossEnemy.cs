using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class MoveBossEnemy : MonoBehaviour
{
    public bool Die = false;
    private float speed = -50;
    private float rspeed = 50;
    private float grspeed = 50;
    [SerializeField] private Rigidbody2D rb;

    GameObject Player;
    GaviController Lifescript;
    private bool Engine;

    //���]
    private bool rflg = true;

    //�d�͔��]
    private bool gflg = false; // �d�͔��]���Ă��Ȃ����
    private bool grflg = false;// �d�͔��]���Ɍ����𔽓]

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
            if (Die == true)
            {
                speed = 0;
            }
            if (rflg)
            {
                //��ɉE�֐i�ݑ�����A�e���󂯂Ȃ��A�i���~�܂�
                rb.velocity = new Vector2(speed, rb.velocity.y);
                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }
            if (!rflg)
            {
                //��ɍ��֐i�ݑ�����A�e���󂯂Ȃ��A�i���~�܂�
                rb.velocity = new Vector2(rspeed, rb.velocity.y);
                // ���[�J�����W��ŁA���݂̉�]�ʂ։��Z����
                this.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                Debug.Log("���]���܂���");
            }

            // gflg��true�ŁAgrflg�Ŕ��΂�����
            if (gflg && grflg)
            {
                //��ɉE�֐i�ݑ�����A�e���󂯂Ȃ��A�i���~�܂�
                rb.velocity = new Vector2(grspeed, rb.velocity.y);
                Physics2D.gravity = new Vector3(0.0f, 9.81f, 0.0f);
                // ���[�J�����W��ŁA���݂̉�]�ʂ։��Z����
                this.transform.rotation = Quaternion.Euler(180.0f, 180.0f, 0.0f);
                Debug.Log("�d�͂𔽓]���Đi�s�����𔽓]���܂���1");
            }

            // gflg��true�ŁAgrflg�Ő��ʂ�����
            if (gflg && !grflg)
            {
                //��ɉE�֐i�ݑ�����A�e���󂯂Ȃ��A�i���~�܂�
                rb.velocity = new Vector2(speed, rb.velocity.y);
                Physics2D.gravity = new Vector3(0.0f, 9.81f, 0.0f);
                // ���[�J�����W��ŁA���݂̉�]�ʂ։��Z����
                this.transform.rotation = Quaternion.Euler(180.0f, 0.0f, 0.0f);
                Debug.Log("�d�͔��]��Ԃ̂܂ܐi�s���������ɖ߂��܂���");
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Reverse")
        {
            rflg = false;
            grflg = true;
        }

        if (coll.gameObject.tag == "RReverse")
        {
            rflg = true;
            grflg = false;
        }

        if (coll.gameObject.tag == "Gravity")
        {
            //�����@�d�́@���]����
            if (gflg == true && grflg == true)
            {
                gflg = true;
                grflg = false;
            }
        }

        if (coll.gameObject.tag == "rGravity")
        {
            // �ŏ��ɍ����������ꍇ�@�d�͂Ɣ��]��false�������ꍇ
            if (gflg == false && grflg == false)
            {
                // ���ׂĂ�true�ɂ���
                gflg = true;
                grflg = true;
            }

            // �d�͂͂��̂܂܂Ō��̐i�s�����ŕԂ��Ă����ꍇ
            if (gflg == true && grflg == false)
            {
                // ���ׂĂ�true�ɂ���
                grflg = true;
            }
        }
    }
}
