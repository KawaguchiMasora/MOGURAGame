using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameElapsedTime : MonoBehaviour
{
    public static GameElapsedTime instance;

    public float targetValue = 3f;

    public float maxValue = 6f;

    public float duration = 30f;

    void Start()
    {
        StartCoroutine(ChangeValueOverTime());
    }

    private IEnumerator ChangeValueOverTime()
    {
        float startValue = targetValue;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // ���Ԍo�߂Ɋ�Â���targetValue���X�V
            targetValue = Mathf.Lerp(startValue, maxValue, elapsedTime / duration);

            // �ω������l���g�p���������������ɏ���
            Debug.Log(targetValue);

            // ���̃t���[���܂ő҂�
            yield return null;
        }

        // �Ō��targetValue��maxValue�ɐݒ�
        targetValue = maxValue;
        Debug.Log("�ω����������܂���: " + targetValue);
    }
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
