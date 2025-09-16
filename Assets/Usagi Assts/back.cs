using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour
{
    private bool isTouchingShop = false;
    private bool isTouchingVinyl = false;
    private bool isTouchingBar = false;
    private bool isTouchingTemple = false;
    private bool isTouchingPizza1 = false;

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

        if (isTouchingBar && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Usagi_Scene");
        }

        if (isTouchingTemple && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Usagi_Scene");
        }

        if (isTouchingPizza1 && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Usagi_Scene");
        }

    }
}