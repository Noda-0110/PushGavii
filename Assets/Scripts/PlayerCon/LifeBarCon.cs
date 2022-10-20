using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBarCon : MonoBehaviour
{
    //プレイヤーとスクリプトの器
    GameObject Player;
    GaviController script;

    [SerializeField]
    Image lifeimg;     //ライフバー
    // Start is called before the first frame update
    void Start()
    {
        //プレイヤー(Chara)を取得し、プレイヤーの持つライフコントローラーを取得する
        Player = GameObject.Find("Chara");
        script = Player.GetComponent<GaviController>();
        //Lifeの画像を持つ
        lifeimg = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        int heart = script.heart;

        if (heart == 4)
        {

            lifeimg.fillAmount = 0.75f;
        }
        if (heart == 3)
        {

            lifeimg.fillAmount = 0.55f;
        }
        if (heart == 2)
        {

            lifeimg.fillAmount = 0.35f;
        }
        if (heart == 1)
        {

            lifeimg.fillAmount = 0.15f;
        }
    }
}