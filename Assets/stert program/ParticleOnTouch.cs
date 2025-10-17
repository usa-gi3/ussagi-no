using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOnTouch : MonoBehaviour
{
    [SerializeField] private GameObject particlePrefab; // �p�[�e�B�N���̃v���n�u�iParticleSystem�t���j
    private GameObject spawnedParticle; // �������ꂽ�p�[�e�B�N���̎Q��

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && spawnedParticle == null)
        {
            // �p�[�e�B�N���𐶐����čĐ�
            Vector3 spawnPos = transform.position + Vector3.up * 3f;
            spawnedParticle = Instantiate(particlePrefab, spawnPos, Quaternion.identity);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && spawnedParticle != null)
        {
            // �p�[�e�B�N����~
            ParticleSystem ps = spawnedParticle.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Stop();
            }

            // �����҂��Ă���j��
            Destroy(spawnedParticle, 1f);
            spawnedParticle = null;
        }
    }
}
