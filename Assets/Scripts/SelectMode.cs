using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMode : MonoBehaviour
{
    public static Stageselect instance;

    public GameObject Player;   //�v���C���[�̈ʒu
    public GameObject[] Worp;   //���[�v��̈ʒu
    private int now = 0;        //���݂̃X�e�[�W
    private int Stagelength;         //�X�e�[�W�̑傫���̊�


    void Start()
    {

    }

    void Update()
    {
        //�ŏ���Worp[0]�̈ʒu�ɃK�[�r�B��u��

        //�X�e�[�W���擾
        Stagelength = Worp.Length-1;

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //�X�e�[�W�̐�����ɂ͐i�܂Ȃ�
            if (Stagelength > now)
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

        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(now==0)
            {
                SceneManager.LoadScene("stage0Wold");

            }
            if(now==1)
            {
                SceneManager.LoadScene("tutorial");
            }
            if(now==2)
            {
                SceneManager.LoadScene("Stage");
            }
            if(now==3)
            {
                SceneManager.LoadScene("Stage");
            }
        }

        Debug.Log(now);
    }

}
