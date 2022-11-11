using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotastageMove : MonoBehaviour
{
    private Vector3 _initalPosision;
    private Quaternion _initalRotation;
    [Header("‰ñ“]‘¬“x")]
    public float speed = 0.5f;
    public bool restart = false;
    public bool Engine = false;

    GameObject Player;
    GaviController Lifescript;
    void Start()
    {
        Player = GameObject.Find("Chara");
        Lifescript = Player.GetComponent<GaviController>();
        // ‰ŠúˆÊ’uE‰Šú‰ñ“]‚Ìæ“¾
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
                transform.Rotate(0f, 0f, -speed);
            }
            if (Input.GetKey(KeyCode.K))
            {
                this.transform.Translate(0f, 0f, 0f);
                transform.Rotate(0f, 0f, speed);
            }
        }
        if (restart == true) { StartReset(); }

    }

    public void StartReset()
    {
        transform.position = _initalPosision; // ˆÊ’u‚Ì‰Šú‰»
        transform.rotation = _initalRotation; // ‰ñ“]‚Ì‰Šú‰»
    }

}
