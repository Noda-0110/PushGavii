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
        // ‰ŠúˆÊ’uE‰Šú‰ñ“]‚Ìæ“¾
        _initalPosision = transform.position;
        _initalRotation = transform.rotation;
    }
    void Update()
    {

        //”ÍˆÍ‚ğ§ŒÀ
        var pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, _minY, _maxY);

        transform.position = pos;


        //‚±‚±‚©‚ç‘€ì
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
        transform.position = _initalPosision; // ˆÊ’u‚Ì‰Šú‰»
        transform.rotation = _initalRotation; // ‰ñ“]‚Ì‰Šú‰»
        restart = false;

    }
}
