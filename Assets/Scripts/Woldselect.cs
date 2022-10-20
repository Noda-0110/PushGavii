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

    void Start()
    {

        lastplay = PlayerPrefs.GetInt("StagePlay", 0);
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
            //�X�e�[�W�̐�����ɂ͐i�܂Ȃ�
            if (Stagelength > now && now < clearwold)
            {
                now++;
                Player.transform.position = Worp[now].transform.position;
            }
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
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
        Debug.Log("���݂̃N���A�����X�e�[�W��" + clearwold + "�܂�");
    }

}
