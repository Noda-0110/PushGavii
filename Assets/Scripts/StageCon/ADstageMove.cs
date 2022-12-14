using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADstageMove : MonoBehaviour
{
    public float speed = 1;
    private Vector3 _initalPosision;
    private Quaternion _initalRotation;
    public bool restart = false;
    [SerializeField] private float _maxX = 1;
    [SerializeField] private float _minX = -1;

    void Start()
    {
        // 初期位置・初期回転の取得
        _initalPosision = transform.position;
        _initalRotation = transform.rotation;
    }
    void Update()
    {
        //範囲を制限
        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, _minX, _maxX);

        transform.position = pos;

        //ここから操作
        pos = transform.position;

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right * Time.deltaTime * 3 * speed);
            print("D");
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(transform.right * Time.deltaTime * 3 * -speed);
            print("A");
        }
        if (restart == true)
        {
            StartReset();
        }
    }

    public void StartReset()
    {
        transform.position = _initalPosision; // 位置の初期化
        transform.rotation = _initalRotation; // 回転の初期化
        restart = false;
    }

}
