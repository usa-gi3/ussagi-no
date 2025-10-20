using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class back : MonoBehaviour
{
    private bool isTouchingShop = false;
    private bool isTouchingVinyl = false;
    private bool isTouchingBar = false;
    private bool isTouchingTemple = false;
    private bool isTouchingPizza1 = false;
    private bool isTouchingofice = false;
    private bool isTouchingmeid = false;

    private SEManager seManager; // �� SEManager�Q�Ɨp

    void Start()
    {
        // �V�[������SEManager��T���ĎQ�Ƃ���
        seManager = FindObjectOfType<SEManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("�Փ˂����I�u�W�F�N�g�̃^�O: " + other.gameObject.tag);

        if (other.CompareTag("shop"))
        {
            isTouchingShop = true;
        }

        if (other.CompareTag("Vinyl"))
        {
            isTouchingVinyl = true;
        }

        if (other.CompareTag("Bar"))
        {
            isTouchingBar = true;
        }

        if (other.CompareTag("Temple"))
        {
            isTouchingTemple = true;
        }

        if (other.CompareTag("Pizza1"))
        {
            isTouchingPizza1 = true;
        }

        if (other.CompareTag("ofice"))
        {
            isTouchingofice = true;
        }

        if (other.CompareTag("meid"))
        {
            isTouchingmeid = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("shop"))
        {
            isTouchingShop = false;
        }

        if (other.CompareTag("Vinyl"))
        {
            isTouchingVinyl = false;
        }

        if (other.CompareTag("Bar"))
        {
            isTouchingBar = false;
        }

        if (other.CompareTag("Temple"))
        {
            isTouchingTemple = false;
        }

        if (other.CompareTag("Pizza1"))
        {
            isTouchingPizza1 = false;
        }

        if (other.CompareTag("ofice"))
        {
            isTouchingofice = false;

        }

        if (other.CompareTag("meid"))
        {
            isTouchingmeid = false;

        }

    }

    void Update()
    {
        if (isTouchingShop && Input.GetKeyDown(KeyCode.Space))
        {
            LoadSceneWithSE("Usagi_Scene");
        }

        if (isTouchingVinyl && Input.GetKeyDown(KeyCode.Space))
        {
            LoadSceneWithSE("Usagi_Scene");
        }

        if (isTouchingBar && Input.GetKeyDown(KeyCode.Space))
        {
            LoadSceneWithSE("Usagi_Scene");
        }

        if (isTouchingTemple && Input.GetKeyDown(KeyCode.Space))
        {
            LoadSceneWithSE("Usagi_Scene");
        }

        if (isTouchingPizza1 && Input.GetKeyDown(KeyCode.Space))
        {
            LoadSceneWithSE("Usagi_Scene");
        }

        if (isTouchingofice && Input.GetKeyDown(KeyCode.Space))
        {
            LoadSceneWithSE("Usagi_Scene");
        }

        if (isTouchingmeid && Input.GetKeyDown(KeyCode.Space))
        {
            LoadSceneWithSE("Usagi_Scene");
        }
    }

    void LoadSceneWithSE(string sceneName)
    {
        //Debug.Log("�ۑ�����ʒu: " + transform.position);
        //PositionMemory.SavePosition(transform.position);

        // SEManager�o�R�Ō��ʉ���炷
        if (seManager != null)
        {
            seManager.PlaysceneChangeBackSE();
        }

        // �����҂��Ă���V�[����؂�ւ���i���ʉ����r���Ő؂�Ȃ��悤�Ɂj
        StartCoroutine(LoadSceneAfterDelay(sceneName, 0.3f));
    }

    System.Collections.IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}