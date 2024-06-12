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

        // ここでスコアを更新する
        int totalScore = plus - minus;

        // テキストにスコアを表示する
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
