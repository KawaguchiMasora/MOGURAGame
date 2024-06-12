using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PrefabWithProbability
{
    public GameObject prefab; // �v���n�u
    public float probability; // �o���m��
}

public class SpawnPrefabsOnColliders : MonoBehaviour
{
    public Collider[] colliders; // �X�|�[������ꏊ�̃R���C�_�[�̔z��
    public PrefabWithProbability[] prefabsWithProbabilities; // �X�|�[������v���n�u�Ƃ��̏o���m���̔z��
    public float maxSpawnCount; // �ő�X�|�[����
    public float fixedY; // �Œ��Y���W
    public int minNumber = 3; // �ŏ��l
    public int maxNumber = 8; // �ő�l

    private Dictionary<Collider, GameObject> spawnedObjects = new Dictionary<Collider, GameObject>();

    void Start()
    {
        SpawnPrefabs();
        // �w�肳�ꂽ�͈͓��̃����_���Ȑ������擾
        
    }

    void SpawnPrefabs()
    {
        // ���݂̃X�|�[�����ꂽ�I�u�W�F�N�g���J�E���g
        int currentSpawnCount = spawnedObjects.Count;

        while (currentSpawnCount < maxSpawnCount)
        {
            // �����_���ȃR���C�_�[��I��
            Collider randomCollider = colliders[Random.Range(0, colliders.Length)];

            // ���ɂ��̃R���C�_�[�ɃX�|�[������Ă��Ȃ����Ƃ��m�F
            if (!spawnedObjects.ContainsKey(randomCollider))
            {
                Vector3 center = randomCollider.bounds.center;
                center.y = fixedY; // �Œ��Y���W�ɐݒ�

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
        // �X�|�[�����ꂽ�I�u�W�F�N�g���j�����ꂽ���ǂ������`�F�b�N
        List<Collider> toRemove = new List<Collider>();

        foreach (var kvp in spawnedObjects)
        {
            if (kvp.Value == null)
            {
                toRemove.Add(kvp.Key);
            }
        }

        // �j�����ꂽ�I�u�W�F�N�g�����X�g����폜
        foreach (var collider in toRemove)
        {
            spawnedObjects.Remove(collider);
        }

        // �K�v�Ȑ��̃v���n�u���ăX�|�[��
        SpawnPrefabs();
    }
}
