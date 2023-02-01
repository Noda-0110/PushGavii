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

    //���]
    private bool erflg = true;

    //�d�͔��]
    private bool egflg = false;
    private bool egrflg = false;

    void Start()
    {
        Player = GameObject.Find("Chara");
        Lifescript = Player.GetComponent<GaviController>();
        Engine = false;
        //���]���Ȃ���
        erflg = true;
        // �d�͔��]���Ȃ���
        egflg = false;
        egrflg = false;
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
            if (erflg)
            {
                //��ɍ��֐i�ݑ�����A�e���󂯂Ȃ��A�i���~�܂�
                rb.velocity = new Vector2(speed, rb.velocity.y);
                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }
            if (!erflg)
            {
                //��ɍ��֐i�ݑ�����A�e���󂯂Ȃ��A�i���~�܂�
                rb.velocity = new Vector2(rspeed, rb.velocity.y);
                // ���[�J�����W��ŁA���݂̉�]�ʂ։��Z����
                this.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            }

            // ���ɖ߂�
            if (!egrflg)
            {
                //��ɉE�֐i�ݑ�����A�e���󂯂Ȃ��A�i���~�܂�
                rb.velocity = new Vector2(speed, rb.velocity.y);
                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                Physics2D.gravity = new Vector2(0.0f, -9.81f);
                erflg = true;
            }

            // gflg��true�ŁAgrflg�Ŕ��΂�����
            if (egflg && egrflg)
            {
                //��ɉE�֐i�ݑ�����A�e���󂯂Ȃ��A�i���~�܂�
                rb.velocity = new Vector2(speed, rb.velocity.y);
                Physics2D.gravity = new Vector2(0.0f, 9.81f);
                // ���[�J�����W��ŁA���݂̉�]�ʂ։��Z����
                this.transform.rotation = Quaternion.Euler(180.0f, 180.0f, 0.0f);
            }

            // gflg��true�ŁAgrflg�Ő��ʂ�����
            if (egflg && !egrflg)
            {
                //��ɉE�֐i�ݑ�����A�e���󂯂Ȃ��A�i���~�܂�
                rb.velocity = new Vector2(rspeed, rb.velocity.y);
                Physics2D.gravity = new Vector2(0.0f, 9.81f);
                // ���[�J�����W��ŁA���݂̉�]�ʂ։��Z����
                this.transform.rotation = Quaternion.Euler(180.0f, 0.0f, 0.0f);
            }
            // gflg��true�ŁAgrflg�Ő��ʂ�����
            if (!egflg && egrflg)
            {
                //��ɉE�֐i�ݑ�����A�e���󂯂Ȃ��A�i���~�܂�
                rb.velocity = new Vector2(speed, rb.velocity.y);
                Physics2D.gravity = new Vector2(0.0f, -9.81f);
                // ���[�J�����W��ŁA���݂̉�]�ʂ։��Z����
                this.transform.rotation = Quaternion.Euler(0f, 180.0f, 0.0f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Reverse")
        {
            erflg = true;
            egrflg = true;
        }

        if (coll.gameObject.tag == "RReverse")
        {
            erflg = false;
            egrflg = false;
        }

        if (coll.gameObject.tag == "Gravity")
        {
            //�����@�d�́@���]����
            if (egflg == false && egrflg == false)
            {
                egflg = true;
                egrflg = true;
            }
            //�����������]
            else if (egflg == false && egrflg == true)
            {
                egflg = true;
                egrflg = false;
            }
            //�d�͂������]
            else if (egflg == true && egrflg == false)
            {
                egflg = false;
                egrflg = true;
            }
            //�����@�d�́@���]
            else if (egflg == true && egrflg == true)
            {
                egflg = false;
                egrflg = false;
            }
        }

        if (coll.gameObject.tag == "rGravity")
        {
            egflg = true;
            egrflg = false;
        }

    }
}

        
