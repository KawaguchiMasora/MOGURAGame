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

            // 時間経過に基づいてtargetValueを更新
            targetValue = Mathf.Lerp(startValue, maxValue, elapsedTime / duration);

            // 変化した値を使用した処理をここに書く
            Debug.Log(targetValue);

            // 次のフレームまで待つ
            yield return null;
        }

        // 最後にtargetValueをmaxValueに設定
        targetValue = maxValue;
        Debug.Log("変化が完了しました: " + targetValue);
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
