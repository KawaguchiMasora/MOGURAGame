using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PrefabWithProbability
{
    public GameObject prefab; // プレハブ
    public float probability; // 出現確率
}

public class SpawnPrefabsOnColliders : MonoBehaviour
{
    public Collider[] colliders; // スポーンする場所のコライダーの配列
    public PrefabWithProbability[] prefabsWithProbabilities; // スポーンするプレハブとその出現確率の配列
    public float maxSpawnCount; // 最大スポーン数
    public float fixedY; // 固定のY座標
    public int minNumber = 3; // 最小値
    public int maxNumber = 8; // 最大値

    private Dictionary<Collider, GameObject> spawnedObjects = new Dictionary<Collider, GameObject>();

    void Start()
    {
        SpawnPrefabs();
        // 指定された範囲内のランダムな整数を取得
        
    }

    void SpawnPrefabs()
    {
        // 現在のスポーンされたオブジェクトをカウント
        int currentSpawnCount = spawnedObjects.Count;

        while (currentSpawnCount < maxSpawnCount)
        {
            // ランダムなコライダーを選択
            Collider randomCollider = colliders[Random.Range(0, colliders.Length)];

            // 既にこのコライダーにスポーンされていないことを確認
            if (!spawnedObjects.ContainsKey(randomCollider))
            {
                Vector3 center = randomCollider.bounds.center;
                center.y = fixedY; // 固定のY座標に設定

                GameObject randomPrefab = GetRandomPrefabBasedOnProbability();
                GameObject spawnedObject = Instantiate(randomPrefab, center, Quaternion.identity);
                spawnedObjects.Add(randomCollider, spawnedObject);
                currentSpawnCount++;
            }
        }
    }

    GameObject GetRandomPrefabBasedOnProbability()
    {
        float totalProbability = 0f;
        foreach (var prefabWithProbability in prefabsWithProbabilities)
        {
            totalProbability += prefabWithProbability.probability;
        }

        float randomPoint = Random.value * totalProbability;

        foreach (var prefabWithProbability in prefabsWithProbabilities)
        {
            if (randomPoint < prefabWithProbability.probability)
            {
                return prefabWithProbability.prefab;
            }
            else
            {
                randomPoint -= prefabWithProbability.probability;
            }
        }

        // Fallback in case of error
        return prefabsWithProbabilities[0].prefab;
    }

    void Update()
    {
        maxSpawnCount = GameElapsedTime.instance.targetValue;

        if(maxSpawnCount == 6)
        {
            maxSpawnCount = 0;
        }
        // スポーンされたオブジェクトが破棄されたかどうかをチェック
        List<Collider> toRemove = new List<Collider>();

        foreach (var kvp in spawnedObjects)
        {
            if (kvp.Value == null)
            {
                toRemove.Add(kvp.Key);
            }
        }

        // 破棄されたオブジェクトをリストから削除
        foreach (var collider in toRemove)
        {
            spawnedObjects.Remove(collider);
        }

        // 必要な数のプレハブを再スポーン
        SpawnPrefabs();
    }
}
