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

    //チュートリアルステージのボタンに付けている処理
    public void StageBack()
    {
        //ステージ選択へ
        SceneManager.LoadScene("stage0Wold");
    }
    public void DateDelete()
    {
        //データを削除する
        PlayerPrefs.DeleteAll();
    }
    public void GameExit()
    {
        //ゲームを終了する
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }

}
