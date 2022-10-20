using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour
{
    public int heart;             //�̗�
    private GameObject Player;     //�v���C���[�̈ʒu
    private GameObject Worp;       //���[�v��̈ʒu
    public GameObject Enemy;       //�G�̈ʒu
    public GameObject EnemyWorp;  //�G�̏o����̈ʒu
    //public GameObject Life; //������Life��\������ꍇ�Ɏg�p

    public GameObject[] LifeCount;
    private int Lifelength;
    private int Gimlength;

    //�M�~�b�N�̏��������s��
    //private WSstageMove WSreset;
    //private ADstageMove ADreset;
    //private RotastageMove Roreset;
    //�v���C���[������(���g�p)
    //public MoveGabi playerreset;

    public bool restart = false;

    void Start()
    {
        Player = GameObject.Find("Chara");
        Worp = GameObject.Find("Worp");
        //�M�~�b�N�̏������̂��߂Ɏ擾
        //WSreset = GameObject.Find("WSbar").gameObject.GetComponent<WSstageMove>();
        //ADreset = GameObject.Find("ADbar").gameObject.GetComponent<ADstageMove>();
        //Roreset = GameObject.Find("Robar").gameObject.GetComponent<RotastageMove>();
        ////�v���C���[������(���g�p)
        //playerreset = GameObject.Find("Chara").gameObject.GetComponent<MoveGabi>();
        //LifeCount[heart].SetActive(true);
    }

    void Update()
    {

        
        LifeCount[heart].SetActive(true);
        //�����Ń��C�t��\������ۂɎg�p
        //Text life_text = Life.GetComponent<Text>();
        //life_text.text = "Life"+heart;

        //���C�t���O�ɂȂ�����Q�[���I�[�o�[��
        if (heart == 0)
        {
            SceneManager.LoadScene("OverScene");
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        Lifelength = LifeCount.Length - 1;
        if (coll.gameObject.tag == "Enemy")
        {
            //���C�t�����炷
            heart--;
            Reset();
            //true�ŃM�~�b�N��������
            //WSreset.restart = true;
            //ADreset.restart = true;
            //Roreset.restart = true;

            restart = true;
            //�v���C���[�����[�v��Ɉړ�
            Player.transform.position = Worp.transform.position;
            Enemy.transform.position = EnemyWorp.transform.position;
            if (restart == true)
            {
                restart = false;
            }

        }
    }

    public void Reset()
    {
        for (int i = 0; i <= Lifelength; i++)
        {
            LifeCount[i].SetActive(false);
        }
    }
}
