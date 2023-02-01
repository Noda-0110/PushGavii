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
    public bool KeyConMode = false;
    [Header("���݂̃��[���h(�N���A�󋵍X�V�p)")]
    public int nowwold;
    [Header("���݂̃X�e�[�W(�N���A�󋵍X�V�p)")]
    public int nowstage;
    [Header("�̗�")]
    public int heart;
    //[Header("�����X�s�[�h")]
    private float speed = 4f;
    private float rspeed = -4f;
    private float grspeed = -4f;
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
    [Header("�X�e�[�W0�ŃL�����o�X")]
    public GameObject canobj;

    [Header("���C���J����")]
    public Camera Camera;
    [Header("�T�u�J����")]
    public Camera subCamera;

    //�L�����o�X
    private GameObject Canvas;

    Animator StageAnimator;

    //�J�����g�p���̃K�[�r�B�̑���𐧌�������
    private bool cammode = false;

    //�T�u�J�����̏ꍇ�̂ݔ�\��
    private GameObject dlcv1;
    private GameObject dlcv2;
    private GameObject dlcv3;
    private GameObject dlcv4;
    private GameObject dlcv5;
    private GameObject dlcv6;
    private GameObject dlcv7;

    private GameObject ChangeButton;


    [Header("���[�v1-1�̏o��")]
    public float worp1_1_X;
    public float worp1_1_Y;
    [Header("���[�v1-2�̏o��")]
    public float worp1_2_X;
    public float worp1_2_Y;
    [Header("���[�v2-1�̏o��")]
    public float worp2_1_X;
    public float worp2_1_Y;
    [Header("���[�v2-2�̏o��")]
    public float worp2_2_X;
    public float worp2_2_Y;
    [Header("���[�v3-1�̏o��")]
    public float worp3_1_X;
    public float worp3_1_Y;
    [Header("���[�v3-2�̏o��")]
    public float worp3_2_X;
    public float worp3_2_Y;

    //���[�v���Ɏg�p
    private bool wflg1_1 = false;
    private bool wflg1_2 = false;
    private bool wflg2_1 = false;
    private bool wflg2_2 = false;
    private bool wflg3_1 = false;
    private bool wflg3_2 = false;


    //�W�����v�̍ő�񐔂������
    private int JampMax;
    //���[���h�N���A�Ɏg��
    private int CrearWorld;

    private bool helpmode1 = false;
    private bool helpmode2 = false;

    private GameObject Player;
    private GameObject Worp;
    private GameObject PushEnter;
    private GameObject EnjDrawn;

    //���]
    private bool rflg = true;

    //�d�͔��]
    private bool gflg = false;
    private bool grflg = false;

    [Header("�J�����̈ʒu")]
    public float cameraX = 5;

    [Header("���[�v��P Tag:Worp1")]
    public GameObject Worp1;
    [Header("���[�v��Q Tag:Worp2")]
    public GameObject Worp2;

    [Header("�v���C���[�̓���(�o�E���h�Ƃ�)")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator Gavianimator;
    [SerializeField] private Animator stage0animator;
    [SerializeField] private Animator Worpanimator;
    [SerializeField] private Animator Dieanimator;

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

    [Header("�K�[�r�B�̎����Ǘ�")]
    public bool GDie = false;

    //��蒼���p
    private int lastplay;

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
        //�v�b�V���G���^�[���擾
        PushEnter = GameObject.Find("PushEnter");

        //�X�e�[�W������p�̃A�j���[�V����
        StageAnimator = subCamera.gameObject.GetComponent<Animator>();
        //Canvas���̃I�u�W�F�N�g
        dlcv1 = GameObject.Find("BGMSlider");
        dlcv2 = GameObject.Find("LifeBack");
        dlcv3 = GameObject.Find("JampBack");
        dlcv4 = GameObject.Find("Life");
        dlcv5 = GameObject.Find("BackButton");
        dlcv6 = GameObject.Find("Number-Life");
        dlcv7 = GameObject.Find("Number-Jump");
        Canvas = GameObject.Find("Canvas");
        ChangeButton = GameObject.Find("SubButton");
        //���߂̓T�u�J�������I�t�ɂ��Ă���
        subCamera.enabled = false;
        // �d�͔��]���Ȃ���
        gflg = false;
        grflg = false;
    }
    void Update()
    {
        //�X�e�[�W�O�ɂ��߂�
        lastplay = PlayerPrefs.GetInt("StagePlay", 1);

            //���[�v���Ɏg�p
            Vector3 pos = gameObject.transform.position;
        if (wflg1_1)
        {
            pos.x = worp1_1_X;
            pos.y = worp1_1_Y;
            gameObject.transform.position = pos;
        }
        if (wflg1_2)
        {
            pos.x = worp1_2_X;
            pos.y = worp1_2_Y;
            gameObject.transform.position = pos;
        }
        if (wflg2_1)
        {
            pos.x = worp2_1_X;
            pos.y = worp2_1_Y;
            gameObject.transform.position = pos;
        }
        if (wflg2_2)
        {
            pos.x = worp2_2_X;
            pos.y = worp2_2_Y;
            gameObject.transform.position = pos;
        }
        if (wflg3_1)
        {
            pos.x = worp3_1_X;
            pos.y = worp3_1_Y;
            gameObject.transform.position = pos;
        }
        if (wflg3_2)
        {
            pos.x = worp3_2_X;
            pos.y = worp3_2_Y;
            gameObject.transform.position = pos;
        }
        //Debug.Log(heart);
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

        //PlayerPrefs.SetInt("WoldClear", 1);
        CrearWorld = PlayerPrefs.GetInt("StagePlay", 1);
        if (restart == true)
        {
            restart = false;
        }
        //�c��W�����v�񐔂�\��
        JampCount[JampEne].SetActive(true);
        if (cammode == false)
        {
            //�G���^�[�ŃG���W�����N��
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Engine = true;
                PushEnter.SetActive(false);
                ChangeButton.SetActive(false);
                Gavianimator.SetBool("Engine", true);
            }
        }
        //�G���W����t������
        if (Engine == true)
        {
            //backbutton.SetActive(false);
            //�n�ʂƂ̐ݒu�󋵂��󂯎��
            isGroundAll = GroundCheck();

            Vector2 keypos = transform.position;
            //�K�[�r�B���L�[����ł���悤�ɂ���
            if (KeyConMode)
            {
                float keyspeed = 0.05f;
                float keyjump = 0.05f;
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    keypos.x -= keyspeed;
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    keypos.x += keyspeed;
                }        
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    keypos.y += keyjump;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    keypos.y -= keyjump;
                }
                transform.position = keypos;

            }
            //�ʏ푀��
            else
            {
                if (rflg)
                {
                    //��ɉE�֐i�ݑ�����A�e���󂯂Ȃ��A�i���~�܂�
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                    this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                    FollowCamera.cameraX = 5;
                }
                if(!rflg)
                {
                    //��ɍ��֐i�ݑ�����A�e���󂯂Ȃ��A�i���~�܂�
                    rb.velocity = new Vector2(rspeed, rb.velocity.y);
                    // ���[�J�����W��ŁA���݂̉�]�ʂ։��Z����
                    this.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                    FollowCamera.cameraX = -5;
                }

                // ���ɖ߂�
                if (!grflg)
                {
                    //��ɉE�֐i�ݑ�����A�e���󂯂Ȃ��A�i���~�܂�
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                    this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                    Physics2D.gravity = new Vector2(0.0f, -9.81f);
                    rflg = true;
                }

                // gflg��true�ŁAgrflg�Ŕ��΂�����
                if (gflg && grflg)
                {
                    //��ɉE�֐i�ݑ�����A�e���󂯂Ȃ��A�i���~�܂�
                    rb.velocity = new Vector2(grspeed, rb.velocity.y);
                    Physics2D.gravity = new Vector2(0.0f, 9.81f);
                    // ���[�J�����W��ŁA���݂̉�]�ʂ։��Z����
                    this.transform.rotation = Quaternion.Euler(180.0f, 180.0f, 0.0f);
                    FollowCamera.cameraX = -5;
                    FollowCamera.cameraY = 0;
                }

                // gflg��true�ŁAgrflg�Ő��ʂ�����
                if (gflg && !grflg)
                {
                    //��ɉE�֐i�ݑ�����A�e���󂯂Ȃ��A�i���~�܂�
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                    Physics2D.gravity = new Vector2(0.0f, 9.81f);
                    // ���[�J�����W��ŁA���݂̉�]�ʂ։��Z����
                    this.transform.rotation = Quaternion.Euler(180.0f, 0.0f, 0.0f);
                    FollowCamera.cameraX = 5;
                    FollowCamera.cameraY = 0;
                }
                // gflg��true�ŁAgrflg�Ő��ʂ�����
                if (!gflg && grflg)
                {
                    //��ɉE�֐i�ݑ�����A�e���󂯂Ȃ��A�i���~�܂�
                    rb.velocity = new Vector2(grspeed, rb.velocity.y);
                    Physics2D.gravity = new Vector2(0.0f, -9.81f);
                    // ���[�J�����W��ŁA���݂̉�]�ʂ։��Z����
                    this.transform.rotation = Quaternion.Euler(0f, 180.0f, 0.0f);
                    FollowCamera.cameraX = -5;
                    FollowCamera.cameraY = 0;
                }

                //transform.Translate(transform.right * Time.deltaTime * 3 * speed);
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
        }
        //�c�@��\��
        LifeCount[heart].SetActive(true);
    }

    //�W�����v����
    private void Jump()
    {

        for (int i = 0; i <= JampMax; i++)
        {
            JampCount[i].SetActive(false);
        }
        if (grflg == false)
        {
            //Force�͌p���I�ɗ͂�������@Impulse�͏u�ԓI�ɗ͂�������
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
        else if(grflg == true)
        {
            //Force�͌p���I�ɗ͂�������@Impulse�͏u�ԓI�ɗ͂�������
            rb.AddForce(Vector2.up * -jump, ForceMode2D.Impulse);
        }
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

    private void OnCollisionEnter2D(Collision2D coll)
    {
        Lifelength = LifeCount.Length - 1;
        if(coll.gameObject.tag == "spike")
        {
            heart--;
            Reset();
            //���C�t���O�ɂȂ�����Q�[���I�[�o�[��
            if (heart == 0)
            {
                GDie = true;
                speed = 0;
                Dieanimator.SetBool("Die", true);
                StartCoroutine(Die());
            }
            IEnumerator Die()
            {
                yield return new WaitForSeconds(5);
                SceneManager.LoadScene("OverScene");
            }
        }
        if (coll.gameObject.tag == "Enemy")
        {
            //���C�t�����炷
            heart--;
            Reset();
            Jumpheel();
            restart = true;
            //���C�t���O�ɂȂ�����Q�[���I�[�o�[��
            if (heart == 0)
            {
                GDie = true;
                speed = 0;
                Dieanimator.SetBool("Die", true);
                StartCoroutine(Die());
            }
            else if (heart >= 1)
            {
                //�v���C���[�����[�v��Ɉړ�
                Player.transform.position = Worp.transform.position;
                // �d�͔��]���Ȃ���
                gflg = false;
                grflg = false;
            }
            IEnumerator Die()
            {
                yield return new WaitForSeconds(5);
                SceneManager.LoadScene("OverScene");
            }

        }
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
            if (gflg == false && grflg == false)
            {
                gflg = true;
                grflg = true;
            }
            //�����������]
            else if(gflg == false && grflg == true)
            {
                gflg = true;
                grflg = false;
            }
            //�d�͂������]
            else if(gflg == true && grflg == false)
            {
                gflg = false;
                grflg = true;
            }
            //�����@�d�́@���]
            else if(gflg == true && grflg == true)
            {
                gflg = false;
                grflg = false;
            }
        }

        if (coll.gameObject.tag == "rGravity")
        {
            gflg = true;
            grflg = false;
        }
    }

    //�����ɓ�����
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Worp1-1")
        {
            wflg1_1 = true;
        }
        if (coll.gameObject.tag == "Worp1-2")
        {
            wflg1_2 = true;
        }
        if (coll.gameObject.tag == "Worp2-1")
        {
            wflg2_1 = true;
        }
        if (coll.gameObject.tag == "Worp2-2")
        {
            wflg2_2 = true;
        }
        if (coll.gameObject.tag == "Worp3-1")
        {
            wflg3_1 = true;
        }
        if (coll.gameObject.tag == "Worp3-2")
        {
            wflg3_2 = true;
        }
        if (coll.gameObject.tag == "Goal")
        {
            speed = 0;
            rspeed = 0;
            //�N���A�X�e�[�W�̍X�V�A�I����ʂ�
            PlayerPrefs.SetInt("StageClear"+ nowwold, nowstage + 1);
            Gavianimator.SetBool("Bye", true);
            StartCoroutine(StageCrear());
        }

        if (coll.gameObject.tag == "LastGoal")
        {
            speed = 0;
            rspeed = 0;
            //�N���A�X�e�[�W�̍X�V�A�I����ʂ�
            PlayerPrefs.SetInt("StageClear" + nowwold, nowstage + 1);
            //�N���A���[���h�̍X�V�A�I����ʂ�
            PlayerPrefs.SetInt("WoldClear", CrearWorld + 1);
            Gavianimator.SetBool("Bye", true);
            StartCoroutine(StageCrear());
        }
        //�Ō�̃X�e�[�W�̃S�[��
        if (coll.gameObject.tag == "Goal0")
        {
            speed = 0;
            rspeed = 0;
            canobj.SetActive(false);
            //�N���A���[���h�̍X�V�A�I����ʂ�
            PlayerPrefs.SetInt("WoldClear", 7);
            Gavianimator.SetBool("Bye", true);
            stage0animator.SetBool("goal0", true);
            StartCoroutine(StageCrear0());
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
        /*
        if (coll.gameObject.tag == "Reverse")
        {
            rflg = false;
        }

        if (coll.gameObject.tag == "RReverse")
        {
            rflg = true;
        }
        */
    }
    IEnumerator StageCrear()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("stage" + CrearWorld);
    }
    IEnumerator StageCrear0()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("stage0Wold");
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
        if (coll.gameObject.tag == "Worp1-1")
        {
            wflg1_1 = false;
        }
        if (coll.gameObject.tag == "Worp1-2")
        {
            wflg1_2 = false;
        }
        if (coll.gameObject.tag == "Worp2-1")
        {
            wflg2_1 = false;
        }
        if (coll.gameObject.tag == "Worp2-2")
        {
            wflg2_2 = false;
        }
        if (coll.gameObject.tag == "Worp3-1")
        {
            wflg3_1 = false;
        }
        if (coll.gameObject.tag == "Worp3-2")
        {
            wflg3_2 = false;
        }

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

    public void PushButtonCamera()
    {
        //�����T�u�J�������I�t��������
        if (!subCamera.enabled)
        {
            //�J�������[�h�I���i����𐧌��j
            cammode = true;
            //�T�u�J�������I���ɂ���
            subCamera.enabled = true;

            //�J�������I�t�ɂ���
            Camera.enabled = false;

            
            StageAnimator.SetBool("PlayMap",true);


            ChangeButton.GetComponentInChildren<Text>().text = "�X�e�[�W�ɖ߂�";

            //PushEnter���\���ɂ���
            PushEnter.SetActive(false);

            dlcv1.SetActive(false);
            dlcv2.SetActive(false);
            dlcv3.SetActive(false);
            dlcv4.SetActive(false);
            dlcv5.SetActive(false);
            dlcv6.SetActive(false);
            dlcv7.SetActive(false);

            //�L�����o�X���f���J�������T�u�J�����I�u�W�F�N�g�ɂ���
            Canvas.GetComponent<Canvas>().worldCamera = subCamera;
        }
        //�����T�u�J�������I����������
        else
        {
            //�J�������[�h�I�t�i���쐧�������j  
            cammode = false;
            //�T�u�J�������I�t�ɂ���
            subCamera.enabled = false;

            //�J�������I���ɂ���
            Camera.enabled = true;


            StageAnimator.SetBool("PlayMap", false);


            ChangeButton.GetComponentInChildren<Text>().text = "�X�e�[�W������";

            //PushEnter��\������
            PushEnter.SetActive(true);

            dlcv1.SetActive(true);
            dlcv2.SetActive(true);
            dlcv3.SetActive(true);
            dlcv4.SetActive(true);
            dlcv5.SetActive(true);
            dlcv6.SetActive(true);
            dlcv7.SetActive(true);

            //�L�����o�X���f���J�������J�����I�u�W�F�N�g�ɂ���
            Canvas.GetComponent<Canvas>().worldCamera = Camera;
        }
    }
}