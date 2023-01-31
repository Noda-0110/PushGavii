using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBar : MonoBehaviour
{
    private Vector3 _initalPosision;
    private Quaternion _initalRotation;


    public float speed = 1;
    public bool Ymove = true;
    [SerializeField] private float _maxY = 1;
    [SerializeField] private float _minY = -1;
    [SerializeField] private float _maxX = 1;
    [SerializeField] private float _minX = -1;
    public bool restart;
    public bool Engine;

    GameObject Player;
    GaviController Lifescript;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Chara");
        Lifescript = Player.GetComponent<GaviController>();
        // ‰ŠúˆÊ’uE‰Šú‰ñ“]‚Ìæ“¾
        _initalPosision = this.transform.position;
        _initalRotation = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        restart = Lifescript.restart;
        Engine = Lifescript.Engine;
        if (Engine == true)
        {
            if (Ymove == true)
            {
                //”ÍˆÍ‚ğ§ŒÀ
                var pos = transform.position;
                pos.y = Mathf.Clamp(pos.y, _minY, _maxY);

                transform.position = pos;

                //‚±‚±‚©‚ç‘€ì
                pos = transform.position;

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
                if (restart == true) { StartReset(); }
            }
            else if (Ymove == false)
            {
                //”ÍˆÍ‚ğ§ŒÀ
                var pos = transform.position;
                pos.x = Mathf.Clamp(pos.x, _minX, _maxX);

                transform.position = pos;

                //‚±‚±‚©‚ç‘€ì
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
        }

    }
    public void StartReset()
    {
        this.transform.position = _initalPosision; // ˆÊ’u‚Ì‰Šú‰»
        this.transform.rotation = _initalRotation; // ‰ñ“]‚Ì‰Šú‰»
        restart = false;
    }

}