using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour
{
    private bool isTouchingUsagi = false;



    void OnTriggerEnter(Collider other)
    {
        Debug.Log("衝突したオブジェクトのタグ: " + other.gameObject.tag);

        if (other.CompareTag("Usagi"))
        {
            isTouchingUsagi = true;
        }
    }




    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Usagi"))
        {
            isTouchingUsagi = false;
        }

    }

    void Update()
    {
        if (isTouchingUsagi && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Usagi_Scene");
        }
    }
}