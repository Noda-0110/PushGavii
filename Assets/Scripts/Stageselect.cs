using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stageselect : MonoBehaviour
{
    public static Stageselect instance;

    public GameObject Player;   //�v���C���[�̈ʒu
    public GameObject[] Worp;   //���[�v��̈ʒu
    private int now = 0;        //���݂̃X�e�[�W
    private int Stagelength;         //�X�e�[�W�̑傫���̊�

    public int clearstage;  //�N���A�����X�e�[�W

    void Start()
    {

    }

    void Update()
    {
        //Worp[1]�܂ł͑I���\
        clearstage = PlayerPrefs.GetInt("Clear",1);
        //�ŏ���Worp[0]�̈ʒu�ɃK�[�r�B��u��

        //�X�e�[�W���擾
        Stagelength = Worp.Length-1;

        if (Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.RightArrow))
        {
            //�X�e�[�W�̐�����ɂ͐i�܂Ȃ�
            if (Stagelength > now && now < clearstage)
            {
                now++;
                Player.transform.position = Worp[now].transform.position;
            }
        }
        if (Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //�O�����O�ɖ߂�Ȃ�
            if (0 < now)
            {
                now--;
                Player.transform.position = Worp[now].transform.position;
            }
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("stage" + now);
        }

        Debug.Log(now);
        Debug.Log("���݂̃N���A�����X�e�[�W��"+clearstage+"�܂�");
    }

}
