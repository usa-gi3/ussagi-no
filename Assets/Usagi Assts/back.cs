using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour
{
    private bool isTouchingShop = false;
    private bool isTouchingVinyl = false;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("衝突したオブジェクトのタグ: " + other.gameObject.tag);

        if (other.CompareTag("shop"))
        {
            isTouchingShop = true;
        }

        if (other.CompareTag("Vinyl"))
        {
            isTouchingVinyl = true;
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
    }

    void Update()
    {
        if (isTouchingShop && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Usagi_Scene");
        }

        if (isTouchingVinyl && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Usagi_Scene");
        }

    }
}