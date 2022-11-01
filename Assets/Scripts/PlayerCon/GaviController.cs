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
    [Header("�w���v�̃I�u�W�F�N�g1")]
    public GameObject HelpPack1;
    [Header("�w���v���o���u���b�N1")]
    public GameObject Help1;
    [Header("�w���v�̃I�u�W�F�N�g2")]
    public GameObject HelpPack2;
    [Header("�w���v���o���u���b�N2")]
    public GameObject Help2;
    //�W�����v�̍ő�񐔂������
    private int JampMax;
    //���[���h�N���A�Ɏg��
    private int CrearWorld;

    private bool helpmode1 = false;
    private bool helpmode2 = false;

    private GameObject Player;
    private GameObject Worp;

    [Header("�v���C���[�̓���(�o�E���h�Ƃ�)")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator Gavianimator;
    [SerializeField] private Animator Worpanimator;

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
        if (helpmode1 == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                HelpPack1.SetActive(false);
                Help1.SetActive(false);
                Time.timeScale = 1;
                helpmode1 = false;
            }
        }
        if (helpmode2 == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                HelpPack2.SetActive(false);
                Help2.SetActive(false);
                Time.timeScale = 1;
                helpmode2 = false;
            }
        }
        //�N���A�󋵂̃��Z�b�g
        /*
        PlayerPrefs.DeleteKey("StagePlay");
        PlayerPrefs.DeleteKey("WoldClear");
        PlayerPrefs.DeleteKey("StageClear");
        */
        CrearWorld = PlayerPrefs.GetInt("StagePlay", 1);
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
            Gavianimator.SetBool("Engine", true);
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

    private void FixedUpdate()
    {
        
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
        }
        if (coll.gameObject.tag == "Goal")
        {
            speed = 0;
            //�N���A�X�e�[�W�̍X�V�A�I����ʂ�
            PlayerPrefs.SetInt("StageClear", nowstage + 1);
            Gavianimator.SetBool("Bye", true);
            StartCoroutine(StageCrear());
        }

        if (coll.gameObject.tag == "LastGoal")
        {
            speed = 0;
            //�N���A�X�e�[�W�̍X�V�A�I����ʂ�
            PlayerPrefs.SetInt("WoldClear", CrearWorld + 1);
            Gavianimator.SetBool("Bye", true);
            StartCoroutine(StageCrear());
        }

        //�n�ʂƂ̐ݒu�𑗂�
        if (coll.gameObject.tag == "ground")
        {
            isGroundEnter = true;
        }
        //�|�b�v�A�b�v��\���P
        if (coll.gameObject.tag == "Help1")
        {
            Engine = false;
            HelpPack1.SetActive(true);
            Time.timeScale = 0;
            helpmode1 = true;
        }        
        //�|�b�v�A�b�v��\���Q
        if (coll.gameObject.tag == "Help2")
        {
            Engine = false;
            HelpPack2.SetActive(true);
            Time.timeScale = 0;
            helpmode2 = true;
        }
    }
    IEnumerator StageCrear()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("stage" + CrearWorld);
    }


    //IEnumerator 
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
        StartCoroutine(WorpAnim());
    }
    IEnumerator WorpAnim()
    {
        Worpanimator.SetBool("StageBack", true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("stage" + CrearWorld);
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