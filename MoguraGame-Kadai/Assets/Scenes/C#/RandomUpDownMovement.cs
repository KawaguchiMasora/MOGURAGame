using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomUpDownMovement : MonoBehaviour
{
    public float upSpeed = 10f; // 上昇速度
    public float downSpeed = 5f; // 下降速度
    public float stopTime = 1f; // 停止時間（秒）
    public float upDownDistance = 2f; // 上下移動距離

    private Vector3 initialPosition; // 初期位置
    private float stopTimer = 0f; // 停止タイマー
    private bool movingUp = true; // 上向きに移動中かどうか

    void Start()
    {
        // 初期位置を設定
        initialPosition = transform.position;
    }

    void Update()
    {
        // 上下の移動
        MoveUpDown();
    }

    void MoveUpDown()
    {
        // 上向きに移動中
        if (movingUp)
        {
            // 上昇
            transform.Translate(Vector3.up * upSpeed * Time.deltaTime);

            // 初期位置からの距離が上下移動距離以上の場合
            if (transform.position.y - initialPosition.y >= upDownDistance)
            {
                // 停止
                stopTimer += Time.deltaTime;
                if (stopTimer >= stopTime)
                {
                    stopTimer = 0f;
                    movingUp = false;
                }
            }
        }
        // 下向きに移動中
        else
        {
            // 下降
            transform.Translate(Vector3.down * downSpeed * Time.deltaTime);

            // 初期位置に戻る
            if (transform.position.y <= initialPosition.y)
            {
                transform.position = initialPosition;
                movingUp = true;
            }
        }
    }
}
