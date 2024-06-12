using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public static UI instance;

    public TMP_Text score;
    public int plus;
    public int minus;

    void Update()
    {

        // �����ŃX�R�A���X�V����
        int totalScore = plus - minus;

        // �e�L�X�g�ɃX�R�A��\������
        score.text = totalScore.ToString();
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
