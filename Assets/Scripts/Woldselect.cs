using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Woldselect : MonoBehaviour
{
    public static Stageselect instance;

    public GameObject Player;   //�v���C���[�̈ʒu
    public GameObject[] Worp;   //���[�v��̈ʒu
    private int now = 0;        //���݂̃X�e�[�W
    private int Stagelength;         //�X�e�[�W�̑傫���̊�
    private int lastplay;

    public int clearwold;  //�N���A�����X�e�[�W

    AudioSource audioSource;
    public AudioClip selectsound;

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
            if (0 < now)
            {
                now--;
                Player.transform.position = Worp[now].transform.position;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("stage" + now);
        }


        Debug.Log(now);
        Debug.Log("���݂̃N���A�������[���h��" + clearwold + "�܂�");
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
    }
    public void DataCLEAR()
    {
        //�N���A�������Ƃɂ���
        PlayerPrefs.DeleteKey("StagePlay");
        PlayerPrefs.SetInt("WoldClear", 6);
        PlayerPrefs.SetInt("StageClear1", 6);
        PlayerPrefs.SetInt("StageClear2", 6);
        PlayerPrefs.SetInt("StageClear3", 6);
        PlayerPrefs.SetInt("StageClear4", 6);
        PlayerPrefs.SetInt("StageClear5", 6);
        PlayerPrefs.SetInt("StageClear6", 6);
    }

}
