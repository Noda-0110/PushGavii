using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //�`���[�g���A���X�e�[�W�̃{�^���ɕt���Ă��鏈��
    public void StageBack()
    {
        //�X�e�[�W�I����
        SceneManager.LoadScene("stage0Wold");
    }
    public void DateDelete()
    {
        //�f�[�^���폜����
        PlayerPrefs.DeleteAll();
    }
    public void GameExit()
    {
        //�Q�[�����I������
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
    }

}
