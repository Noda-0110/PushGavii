using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform playerTr; // �v���C���[��Transform
    [SerializeField] Vector3 cameraOrgPos = new Vector3(0, 0, -10f); // �J�����̏����ʒu�ʒu 
    [SerializeField] Vector2 camaraMaxPos = new Vector2(5, 5); // �J�����̉E����E���W
    [SerializeField] Vector2 camaraMinPos = new Vector2(-5, -5); // �J�����̍������E���W

    public static int cameraX = 5;
    public static int cameraY = 2;

    void LateUpdate()
    {

        Vector3 playerPos = playerTr.position; // �v���C���[�̈ʒu
        Vector3 camPos = transform.position; // �J�����̈ʒu

        cameraOrgPos.x = cameraX;
        cameraOrgPos.y = cameraY;

        // ���炩�Ƀv���C���[�̏ꏊ�ɒǏ]
        camPos = Vector3.Lerp(transform.position, playerPos + cameraOrgPos, 1.5f * Time.deltaTime);

        // �J�����̈ʒu�𐧌�
        camPos.x = Mathf.Clamp(camPos.x, camaraMinPos.x, camaraMaxPos.x);
        camPos.y = Mathf.Clamp(camPos.y, camaraMinPos.y, camaraMaxPos.y);
        camPos.z = -10f;
        transform.position = camPos;

    }
}
