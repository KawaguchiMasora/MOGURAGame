using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectUpDownSpeed : MonoBehaviour
{
    public float targetYPosition = 5f; // 目標のY座標
    public float duration = 2f; // アニメーションの時間

    private float initialYPosition; // 初期位置のY座標

    private void Start()
    {
        // 初期位置のY座標を取得
        initialYPosition = transform.position.y;

        //Yoyo
        // Y座標をtargetYPositionに変化させ、Yoyoで戻るアニメーションを設定
        transform.DOMoveY(targetYPosition, duration)
                 .SetLoops(-1, LoopType.Yoyo) // 無限ループ
                 .SetEase(Ease.InOutQuad) // イージングを設定
                 .OnStepComplete(CheckReturnPosition); // Tweenアニメーションが終了した時にコールバックを設定
    }

    // Tweenアニメーションが終了した時に呼ばれるメソッド
    private void CheckReturnPosition()
    {
        if (Mathf.Abs(transform.position.y - initialYPosition) < 0.01f)
        {
            Destroy(gameObject);
        }
    }
}
