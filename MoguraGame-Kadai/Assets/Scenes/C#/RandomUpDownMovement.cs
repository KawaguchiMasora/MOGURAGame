using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomUpDownMovement : MonoBehaviour
{
    public float upSpeed = 10f; // �㏸���x
    public float downSpeed = 5f; // ���~���x
    public float stopTime = 1f; // ��~���ԁi�b�j
    public float upDownDistance = 2f; // �㉺�ړ�����

    private Vector3 initialPosition; // �����ʒu
    private float stopTimer = 0f; // ��~�^�C�}�[
    private bool movingUp = true; // ������Ɉړ������ǂ���

    void Start()
    {
        // �����ʒu��ݒ�
        initialPosition = transform.position;
    }

    void Update()
    {
        // �㉺�̈ړ�
        MoveUpDown();
    }

    void MoveUpDown()
    {
        // ������Ɉړ���
        if (movingUp)
        {
            // �㏸
            transform.Translate(Vector3.up * upSpeed * Time.deltaTime);

            // �����ʒu����̋������㉺�ړ������ȏ�̏ꍇ
            if (transform.position.y - initialPosition.y >= upDownDistance)
            {
                // ��~
                stopTimer += Time.deltaTime;
                if (stopTimer >= stopTime)
                {
                    stopTimer = 0f;
                    movingUp = false;
                }
            }
        }
        // �������Ɉړ���
        else
        {
            // ���~
            transform.Translate(Vector3.down * downSpeed * Time.deltaTime);

            // �����ʒu�ɖ߂�
            if (transform.position.y <= initialPosition.y)
            {
                transform.position = initialPosition;
                movingUp = true;
            }
        }
    }
}
