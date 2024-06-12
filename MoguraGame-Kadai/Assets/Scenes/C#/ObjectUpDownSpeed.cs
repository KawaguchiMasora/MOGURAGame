using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectUpDownSpeed : MonoBehaviour
{
    public float targetYPosition = 5f; // �ڕW��Y���W
    public float duration = 2f; // �A�j���[�V�����̎���

    private float initialYPosition; // �����ʒu��Y���W

    private void Start()
    {
        // �����ʒu��Y���W���擾
        initialYPosition = transform.position.y;

        //Yoyo
        // Y���W��targetYPosition�ɕω������AYoyo�Ŗ߂�A�j���[�V������ݒ�
        transform.DOMoveY(targetYPosition, duration)
                 .SetLoops(-1, LoopType.Yoyo) // �������[�v
                 .SetEase(Ease.InOutQuad) // �C�[�W���O��ݒ�
                 .OnStepComplete(CheckReturnPosition); // Tween�A�j���[�V�������I���������ɃR�[���o�b�N��ݒ�
    }

    // Tween�A�j���[�V�������I���������ɌĂ΂�郁�\�b�h
    private void CheckReturnPosition()
    {
        if (Mathf.Abs(transform.position.y - initialYPosition) < 0.01f)
        {
            Destroy(gameObject);
        }
    }
}
