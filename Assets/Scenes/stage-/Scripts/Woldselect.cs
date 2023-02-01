using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Woldselect : MonoBehaviour
{
    public static Stageselect instance;

    //�I�������Ƃ��̈ʒu������
    private int worpnum = 0;
    public GameObject Player;   //�v���C���[�̈ʒu
    public GameObject[] Worp;   //���[�v��̈ʒu
    public GameObject[] WorpLock;   //���[�v��̈ʒu
    private int now = 0;        //���݂̃X�e�[�W
    private int Stagelength;         //�X�e�[�W�̑傫���̊�
    private int lastplay;

    

    public int clearwold;  //�N���A�����X�e�[�W

    [SerializeField] private Animator Worpanimator;
    AudioSource audioSource;
    public AudioClip selectsound;
    public AudioClip worpsound;
    private bool endstage = false;

    void Start()
    {

        audioSource = GetComponent<AudioSource>();

        lastplay = PlayerPrefs.GetInt("StagePlay", 1);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("stage" + lastplay);
        }
        Player.transform.position = Worp[lastplay].transform.position;

        now = lastplay;
    }

    void Update()
    {
        //stage�̍Ō���N���A�����WoldClear���X�V�����
        clearwold = PlayerPrefs.GetInt("WoldClear", 1);
        //�ŏ���Worp[0]�̈ʒu�ɃK�[�r�B��u��

        //�X�e�[�W���擾
        Stagelength = Worp.Length - 1;

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            audioSource.PlayOneShot(selectsound);
            //�X�e�[�W�̐�����ɂ͐i�܂Ȃ�
            if (Stagelength > now && now < clearwold)
            {
                now++;
                Player.transform.position = Worp[now].transform.position;
            }
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            audioSource.PlayOneShot(selectsound);
            //�O�����O�ɖ߂�Ȃ�

            if (endstage == false)
            {
                if (1 < now)
                {
                    now--;
                    Player.transform.position = Worp[now].transform.position;
                }
            }
            if(endstage == true)
            {
                if (0 < now)
                {
                    now--;
                    Player.transform.position = Worp[now].transform.position;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            worpnum = now;
            audioSource.PlayOneShot(worpsound);
            StartCoroutine(WorpAnim());
        }
        IEnumerator WorpAnim()
        {
            Worpanimator.SetBool("StageBack", true);
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("stage" + worpnum);
        }

        if(clearwold == 1)
        {
            WorpLock[0].SetActive(false);
        }
        if(clearwold >= 2)
        {
            WorpLock[1].SetActive(false);
            WorpLock[0].SetActive(false);
        }
        if(clearwold >= 3)
        {
            WorpLock[1].SetActive(false);
            WorpLock[2].SetActive(false);
            WorpLock[0].SetActive(false);
        }
        if(clearwold >= 4)
        {
            WorpLock[1].SetActive(false);
            WorpLock[2].SetActive(false);
            WorpLock[3].SetActive(false);
            WorpLock[0].SetActive(false);
        }
        if(clearwold >= 5)
        {
            WorpLock[1].SetActive(false);
            WorpLock[2].SetActive(false);
            WorpLock[3].SetActive(false);
            WorpLock[4].SetActive(false);
            WorpLock[0].SetActive(false);
        }
        //�X�e�[�W�U�͉�����Ȃ�
        if(clearwold >= 6)
        {
            WorpLock[1].SetActive(false);
            WorpLock[2].SetActive(false);
            WorpLock[3].SetActive(false);
            WorpLock[4].SetActive(false);
            WorpLock[6].SetActive(false);
            WorpLock[0].SetActive(false);
            endstage = true;

        }
        //�X�e�[�W�O�N���A��ɃX�e�[�W�U���
        if(clearwold >= 7)
        {
            WorpLock[1].SetActive(false);
            WorpLock[2].SetActive(false);
            WorpLock[3].SetActive(false);
            WorpLock[4].SetActive(false);
            WorpLock[5].SetActive(false);
            WorpLock[6].SetActive(false);
            WorpLock[0].SetActive(false);
        }

        //Debug.Log(now);
        //Debug.Log("���݂̃N���A�������[���h��" + clearwold + "�܂�");
    }



    public void DataReset()
    {
        //�N���A�󋵂̃��Z�b�g
        PlayerPrefs.DeleteKey("StagePlay");
        PlayerPrefs.DeleteKey("WoldClear");
        PlayerPrefs.DeleteKey("StageClear1");
        PlayerPrefs.DeleteKey("StageClear2");
        PlayerPrefs.DeleteKey("StageClear3");
        PlayerPrefs.DeleteKey("StageClear4");
        PlayerPrefs.DeleteKey("StageClear5");
        PlayerPrefs.DeleteKey("StageClear6");
        PlayerPrefs.DeleteKey("movie1");
        PlayerPrefs.DeleteKey("movie2");
        PlayerPrefs.DeleteKey("movie3");
        PlayerPrefs.DeleteKey("movie4");
        PlayerPrefs.DeleteKey("movie5");
        PlayerPrefs.DeleteKey("movie6");
    }
    public void DataCLEAR()
    {
        //�N���A�������Ƃɂ���
        PlayerPrefs.DeleteKey("StagePlay");
        PlayerPrefs.SetInt("WoldClear", 7);
        PlayerPrefs.SetInt("StageClear1", 7);
        PlayerPrefs.SetInt("StageClear2", 7);
        PlayerPrefs.SetInt("StageClear3", 7);
        PlayerPrefs.SetInt("StageClear4", 7);
        PlayerPrefs.SetInt("StageClear5", 7);
        PlayerPrefs.SetInt("StageClear6", 7);
    }

}