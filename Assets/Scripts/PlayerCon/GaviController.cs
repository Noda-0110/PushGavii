using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]

public class GaviController : MonoBehaviour
{
    [Header("���݂̃X�e�[�W(�N���A�󋵍X�V�p)")]
    public int nowstage;
    [Header("�̗�")]
    public int heart;
    [Header("�����X�s�[�h")]
    public float speed = 0;
    [Header("�W�����v�̍���")]
    public float jump = 0;
    [Header("�W�����v��")]
    public int JampEne = 3;
    //�W�����v�̍ő�񐔂������
    private int JampMax;
    [Header("�v���C���[�̓���(�o�E���h�Ƃ�)")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    private GameObject Player;
    private GameObject Worp;
    [Header("�w���v�̃I�u�W�F�N�g")]
    public GameObject Help;
    [Header("�G�̈ʒu")]
    public GameObject Enemy;
    [Header("�G�̏o����̈ʒu")]
    public GameObject EnemyWorp;

    //�ڒn����ƈړ��\��
    [Header("")]
    private bool isGroundEnter, isGroundStay, isGroundExit, isGroundCheck, isGroundAll;
    [Header("true�œ����o��")]
    public bool Engine;

    [Header("�I����ʂ֖߂�{�^��")]
    public GameObject backbutton;
    [Header("�W�����v�񐔂̐���������z��")]
    public GameObject[] JampCount;
    [Header("�c��c�@�̐���������z��")]
    public GameObject[] LifeCount;
    //�̗͔z��̒���
    private int Lifelength;

    [Header("���Z�b�g���Ǘ�")]
    public bool restart = false;

    void Start()
    {
        //�W�����v�̍ő�񐔂��擾
        JampMax = JampEne;
        //�߂�{�^����\��
        backbutton.SetActive(true);
        //�G���W�����~
        Engine = false;
        //�ݒu�󋵂�false��
        isGroundAll = false;
        //�v���C���[���擾
        Player = GameObject.Find("Chara");
        //�����ʒu���擾
        Worp = GameObject.Find("Worp");
    }
    void Update()
    {
        if (restart == true)
        {
            restart = false;
        }
        //�c��W�����v�񐔂�\��
        JampCount[JampEne].SetActive(true);

        //�G���^�[�ŃG���W�����N��
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Engine = true;
            animator.SetBool("Engine", true);
        }
        //�G���W����t������
        if (Engine == true)
        {
            backbutton.SetActive(false);
            //�n�ʂƂ̐ݒu�󋵂��󂯎��
            isGroundAll = GroundCheck();
            //��ɉE�֐i�ݑ�����A�e���󂯂Ȃ��A�i���~�܂�
            rb.velocity = new Vector2(speed, rb.velocity.y);
            //�ڒn���Ă���΃W�����v�\
            if (Input.GetKeyDown(KeyCode.C) && isGroundAll == true && JampEne > 0)
            {
                JampEne--;
                Jump();//�W�����v����
            }        //�ڒn���Ă���΃W�����v�\
            if (Input.GetKeyDown(KeyCode.M) && isGroundAll == true && JampEne > 0)
            {
                JampEne--;
                Jump();//�W�����v����
            }
        }



        //�c�@��\��
        LifeCount[heart].SetActive(true);

        //���C�t���O�ɂȂ�����Q�[���I�[�o�[��
        if (heart == 0)
        {
            SceneManager.LoadScene("OverScene");
        }

    }

    //�W�����v����
    private void Jump()
    {
        for (int i = 0; i <= JampMax; i++)
        {
            JampCount[i].SetActive(false);
        }
        //Force�͌p���I�ɗ͂�������@Impulse�͏u�ԓI�ɗ͂�������
        rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
    }

    //�ݒu�󋵂𒲂ׂēn��
    public bool GroundCheck()
    {
        if (isGroundEnter || isGroundStay)
        {
            isGroundCheck = true;
        }
        else if (isGroundExit)
        {
            isGroundCheck = false;
        }
        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;

        return isGroundCheck;
    }


    //�����ɓ�����
    private void OnTriggerEnter2D(Collider2D coll)
    {
        Lifelength = LifeCount.Length - 1;
        if (coll.gameObject.tag == "Enemy")
        {
            //���C�t�����炷
            heart--;
            Reset();
            Jumpheel();
            restart = true;
            //�v���C���[�����[�v��Ɉړ�
            Player.transform.position = Worp.transform.position;
            Enemy.transform.position = EnemyWorp.transform.position;
        }

        if (coll.gameObject.tag == "Help")
        {
            Help.SetActive(true);
            Engine = false;
        }

        if (coll.gameObject.tag == "Goal")
        {
            //�N���A�X�e�[�W�̍X�V�A�I����ʂ�
            PlayerPrefs.SetInt("StageClear", nowstage + 1);
            SceneManager.LoadScene("stage" + nowstage);
        }
        //�n�ʂƂ̐ݒu�𑗂�
        if (coll.gameObject.tag == "ground")
        {
            isGroundEnter = true;
        }
    }
    public void Reset()
    {
        for (int i = 0; i <= Lifelength; i++)
        {
            LifeCount[i].SetActive(false);
        }
    }

    //�����̒��ɂ���
    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "ground")
        {
            isGroundStay = true;
        }
    }

    //��������o��
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "ground")
        {
            isGroundExit = true;
        }
    }

    public void StageBack()
    {
        SceneManager.LoadScene("stage" + nowstage);
    }
    public void Jumpheel()
    {
        for (int i = 0; i <= JampMax; i++)
        {
            JampCount[i].SetActive(false);
        }
        JampEne = 3;
    }
}