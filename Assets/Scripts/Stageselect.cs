using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stageselect : MonoBehaviour
{
    public static Stageselect instance;

    [Header("���݂̃N���A�����X�e�[�W")]
    public int clearstage;  //�N���A�����X�e�[�W
    public GameObject Player;   //�v���C���[�̈ʒu
    public GameObject[] Worp;   //���[�v��̈ʒu
    private int nowStage = 0;        //���݂̃X�e�[�W
    private int Stagelength;         //�X�e�[�W�̑傫���̊�
    [Header("���݂̃��[���h�̐��������")]
    public int nowWold = 0;        //���݂̃��[���h


    void Start()
    {
    }

    void Update()
    {
        //�Ō�ɗV�񂾃X�e�[�W
        PlayerPrefs.SetInt("StagePlay", nowWold);
        //Worp[1]�܂ł͑I���\
        clearstage = PlayerPrefs.GetInt("StageClear", 6);
        //�ŏ���Worp[0]�̈ʒu�ɃK�[�r�B��u��

        //�X�e�[�W���擾
        Stagelength = Worp.Length - 1;

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //�X�e�[�W�̐�����ɂ͐i�܂Ȃ�
            if (Stagelength > nowStage && nowStage < clearstage)
            {
                nowStage++;
                Player.transform.position = Worp[nowStage].transform.position;
            }
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //�O�����O�ɖ߂�Ȃ�
            if (0 < nowStage)
            {
                nowStage--;
                Player.transform.position = Worp[nowStage].transform.position;
            }
        }

        if (nowStage > 0)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("stage" + nowWold + "-" + nowStage);
            }
        }
        if (nowStage == 0)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("stage0Wold");
            }
        }

        Debug.Log(nowStage);
        Debug.Log("���݂̃N���A�����X�e�[�W��" + clearstage + "�܂�");
    }

}
