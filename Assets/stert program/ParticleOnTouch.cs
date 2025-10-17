using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOnTouch : MonoBehaviour
{
    [SerializeField] private GameObject particlePrefab; // パーティクルのプレハブ（ParticleSystem付き）
    private GameObject spawnedParticle; // 生成されたパーティクルの参照

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && spawnedParticle == null)
        {
            // パーティクルを生成して再生
            Vector3 spawnPos = transform.position + Vector3.up * 3f;
            spawnedParticle = Instantiate(particlePrefab, spawnPos, Quaternion.identity);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && spawnedParticle != null)
        {
            // パーティクル停止
            ParticleSystem ps = spawnedParticle.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Stop();
            }

            // 少し待ってから破壊
            Destroy(spawnedParticle, 1f);
            spawnedParticle = null;
        }
    }
}
