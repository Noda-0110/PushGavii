using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Materials�Ŗ��C���O�ɂ��Ă���ARigitbody��Material

//�R���|�[�l���g�̒ǉ�
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class TutorialGabi : MonoBehaviour
{
    public float speed = 0;
    public float jump = 0;
    [SerializeField] private Rigidbody2D rb;

    //�ڒn����ƈړ��\��
    private bool isGroundEnter, isGroundStay, isGroundExit, isGroundCheck, isGroundAll;
    public GameObject[] JampCount;
    public int JampEne = 3;
    private int JampMax;



    void Start()
    {
        //�W�����v�̍ő�񐔂��擾
        JampMax = JampEne;
        isGroundAll = false;

    }

    void Update()
    {
        //�c��W�����v�񐔂�\��
        JampCount[JampEne].SetActive(true);

        //�n�ʂƂ̐ݒu�󋵂��󂯎��
        isGroundAll = GroundCheck();
        //��ɉE�֐i�ݑ�����A�e���󂯂Ȃ��A�i���~�܂�
        rb.velocity = new Vector2(speed, rb.velocity.y);
        //�ڒn���Ă���΃W�����v�\
        if (Input.GetKeyDown(KeyCode.C)&& isGroundAll == true && JampEne > 0)
        {
            JampEne--;
            Jump();//�W�����v����
        }        //�ڒn���Ă���΃W�����v�\
        if (Input.GetKeyDown(KeyCode.M)&& isGroundAll == true && JampEne > 0)
        {
            JampEne--;
            Jump();//�W�����v����
        }
    }

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
        if (coll.gameObject.tag == "Goal")
        {
            //�N���A�X�e�[�W�̍X�V�A�I����ʂ�
            PlayerPrefs.SetInt("Clear", 2);
            SceneManager.LoadScene("stage0Wold");
        }
        //�n�ʂƂ̐ݒu�𑗂�
        if (coll.gameObject.tag == "ground")
        {
            isGroundEnter = true;
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
        SceneManager.LoadScene("stage0Wold");
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
