using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSstageMove : MonoBehaviour
{
    private Vector3 pos;
    public float speed = 1;
    private Vector3 _initalPosision;
    private Quaternion _initalRotation;
    public bool restart = false;
    [SerializeField] private float _maxY = 1;
    [SerializeField] private float _minY = -1;

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
        pos.y = Mathf.Clamp(pos.y, _minY, _maxY);

        transform.position = pos;


        //ここから操作
        //pos = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.up * Time.deltaTime * 3 * speed);
            print("W");
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(transform.up * Time.deltaTime * 3 * -speed);
            print("S");
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
