using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBarCon : MonoBehaviour
{
    //�v���C���[�ƃX�N���v�g�̊�
    GameObject Player;
    GaviController script;

    [SerializeField]
    Image lifeimg;     //���C�t�o�[
    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[(Chara)���擾���A�v���C���[�̎����C�t�R���g���[���[���擾����
        Player = GameObject.Find("Chara");
        script = Player.GetComponent<GaviController>();
        //Life�̉摜������
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