using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotastageMove : MonoBehaviour
{
    private Vector3 _initalPosision;
    private Quaternion _initalRotation;
    public bool restart = false;
    public bool Engine = false;

    GameObject Player;
    GaviController Lifescript;
    void Start()
    {
        Player = GameObject.Find("Chara");
        Lifescript = Player.GetComponent<GaviController>();
        // 初期位置・初期回転の取得
        _initalPosision = transform.position;
        _initalRotation = transform.rotation;
    }
    void Update()
    {
        Engine = Lifescript.Engine;
        if (Engine == true)
        {
            restart = Lifescript.restart;
            if (Input.GetKey(KeyCode.L))
            {
                this.transform.Translate(0f, 0f, 0f);
                transform.Rotate(0f, 0f, -0.1f);
            }
            if (Input.GetKey(KeyCode.K))
            {
                this.transform.Translate(0f, 0f, 0f);
                transform.Rotate(0f, 0f, 0.1f);
            }
        }
        if (restart == true) { StartReset(); }

    }

    public void StartReset()
    {
        transform.position = _initalPosision; // 位置の初期化
        transform.rotation = _initalRotation; // 回転の初期化
    }

}
