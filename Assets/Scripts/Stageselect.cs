using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stageselect : MonoBehaviour
{
    public static Stageselect instance;
    [Header("���݂̃N���A�����X�e�[�W")]
    public int clearstage1;  //�N���A�����X�e�[�W
    public int clearstage2;  //�N���A�����X�e�[�W
    public int clearstage3;  //�N���A�����X�e�[�W
    public int clearstage4;  //�N���A�����X�e�[�W
    public int clearstage5;  //�N���A�����X�e�[�W
    public int clearstage6;  //�N���A�����X�e�[�W
    public GameObject Player;   //�v���C���[�̈ʒu
    public GameObject[] Worp;   //���[�v��̈ʒu
    private int nowStage = 0;        //���݂̃X�e�[�W
    private int Stagelength;         //�X�e�[�W�̑傫���̊�
    [Header("���݂̃��[���h�̐��������")]
    public int nowWold = 0;        //���݂̃��[���h

    [SerializeField] private Animator Worpanimator;
    public AudioClip worpsound;
    AudioSource audioSource;
    public AudioClip selectsound;
    AudioSource audioSource2;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource2 = GetComponent<AudioSource>();
    }

    void Update()
    {
        //�Ō�ɗV�񂾃X�e�[�W������
        PlayerPrefs.SetInt("StagePlay", nowWold);

        //Worp[1]�܂ł͑I���\
        for (int a = 0; a >= 5; a++) {
        }
        //�ŏ���Worp[0]�̈ʒu�ɃK�[�r�B��u��

        //�X�e�[�W���擾
        Stagelength = Worp.Length - 1;
        if (nowWold == 1)
        {
            clearstage1 = PlayerPrefs.GetInt("StageClear" + 1, 1); 
            stagemove(1);
        }
        if (nowWold == 2)
        {
            clearstage2 = PlayerPrefs.GetInt("StageClear" + 2, 1); 
            stagemove(2);
        }
        if (nowWold == 3)
        {
            clearstage3 = PlayerPrefs.GetInt("StageClear" + 3, 1); 
            stagemove(3);
        }
        if (nowWold == 4)
        {
            clearstage4 = PlayerPrefs.GetInt("StageClear" + 4, 1); 
            stagemove(4);
        }
        if (nowWold == 5)
        {
            clearstage5 = PlayerPrefs.GetInt("StageClear" + 5, 1); 
            stagemove(5);
        }
        if (nowWold == 6)
        {
            clearstage6 = PlayerPrefs.GetInt("StageClear" + 6, 1); 
            stagemove(6);
        }
        
        Debug.Log(nowStage);
        switch(nowWold){
            case 1:
                Debug.Log("���݂̃N���A�����X�e�[�W��" + clearstage1 + "�܂�");
                break;
            case 2:
                Debug.Log("���݂̃N���A�����X�e�[�W��" + clearstage2 + "�܂�");
                break;
            case 3:
                Debug.Log("���݂̃N���A�����X�e�[�W��" + clearstage3 + "�܂�");
                break;
            case 4:
                Debug.Log("���݂̃N���A�����X�e�[�W��" + clearstage4 + "�܂�");
                break;
            case 5:
                Debug.Log("���݂̃N���A�����X�e�[�W��" + clearstage5 + "�܂�");
                break;
            case 6:
                Debug.Log("���݂̃N���A�����X�e�[�W��" + clearstage6 + "�܂�");
                break;
        }
    }
    public void stagemove(int Nowold)
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            audioSource.PlayOneShot(selectsound);
            if (Nowold == 1)
            {
                //�X�e�[�W�̐�����ɂ͐i�܂Ȃ�
                if (Stagelength > nowStage && nowStage < clearstage1)
                {
                    nowStage++;
                    Player.transform.position = Worp[nowStage].transform.position;
                }
            }
            if (Nowold == 2)
            {
                //�X�e�[�W�̐�����ɂ͐i�܂Ȃ�
                if (Stagelength > nowStage && nowStage < clearstage2)
                {
                    nowStage++;
                    Player.transform.position = Worp[nowStage].transform.position;
                }
            }
            if (Nowold == 3)
            {
                //�X�e�[�W�̐�����ɂ͐i�܂Ȃ�
                if (Stagelength > nowStage && nowStage < clearstage3)
                {
                    nowStage++;
                    Player.transform.position = Worp[nowStage].transform.position;
                }
            }
            if (Nowold == 4)
            {
                //�X�e�[�W�̐�����ɂ͐i�܂Ȃ�
                if (Stagelength > nowStage && nowStage < clearstage4)
                {
                    nowStage++;
                    Player.transform.position = Worp[nowStage].transform.position;
                }
            }
            if (Nowold == 5)
            {
                //�X�e�[�W�̐�����ɂ͐i�܂Ȃ�
                if (Stagelength > nowStage && nowStage < clearstage5)
                {
                    nowStage++;
                    Player.transform.position = Worp[nowStage].transform.position;
                }
            }
            if (Nowold == 6)
            {
                //�X�e�[�W�̐�����ɂ͐i�܂Ȃ�
                if (Stagelength > nowStage && nowStage < clearstage6)
                {
                    nowStage++;
                    Player.transform.position = Worp[nowStage].transform.position;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            audioSource.PlayOneShot(selectsound);
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
                audioSource.PlayOneShot(worpsound);
                StartCoroutine(WorpAnim());
            }
        }
        IEnumerator WorpAnim()
        {
            Worpanimator.SetBool("StageBack", true);
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("stage" + nowWold + "-" + nowStage);
        }
        if (nowStage == 0)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                audioSource.PlayOneShot(worpsound);
                StartCoroutine(WorpAnim2());
            }
        }
        IEnumerator WorpAnim2()
        {
            Worpanimator.SetBool("StageBack", true);
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("stage0Wold");
        }
    }
}
