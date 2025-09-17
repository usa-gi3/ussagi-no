using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    private bool isTouchingShop = false;
    private bool isTouchingVinyl = false;
    private bool isTouchingBar = false;
    private bool isTouchingTemple = false;
    private bool isTouchingPizza1 = false;
    private bool isTouchingOfice = false;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("衝突したオブジェクトのタグ: " + other.gameObject.tag);

        if (other.gameObject.CompareTag("shop"))
        {
            isTouchingShop = true;
        }

        if (other.gameObject.CompareTag("Vinyl"))
        {
            isTouchingVinyl = true;
        }


        if (other.gameObject.CompareTag("Bar"))
        {
            isTouchingBar = true;
        }

        if (other.gameObject.CompareTag("Temple"))
        {
            isTouchingTemple = true;
        }

        if (other.CompareTag("Pizza1"))
        {
            isTouchingPizza1 = true;
        }

        if (other.CompareTag("ofice"))
        {
            isTouchingOfice = true;
        }


    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("shop"))
        {
            isTouchingShop = false;
        }

        if (other.gameObject.CompareTag("Vinyl"))
        {
            isTouchingVinyl = false;
        }

        if (other.gameObject.CompareTag("Bar"))
        {
            isTouchingBar = false;
        }

        if (other.gameObject.CompareTag("Temple"))
        {
            isTouchingTemple = false;
        }

        if (other.CompareTag("Pizza1"))
        {
            isTouchingPizza1 = false;
        }

        if (other.CompareTag("Ofice"))
        {
            isTouchingOfice = false;
        }
    }

    void Update()
    {
        if (isTouchingShop && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("保存する位置: " + transform.position);
            PositionMemory.SavePosition(transform.position);
            SceneManager.LoadScene("Shop_Scene");
        }

        if (isTouchingVinyl && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("保存する位置: " + transform.position);
            PositionMemory.SavePosition(transform.position);
            SceneManager.LoadScene("Vinyl_Scene");
        }

        if (isTouchingBar && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("保存する位置: " + transform.position);
            PositionMemory.SavePosition(transform.position);
            SceneManager.LoadScene("Bar_Scene");
        }

        if (isTouchingTemple && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("保存する位置: " + transform.position);
            PositionMemory.SavePosition(transform.position);
            SceneManager.LoadScene("Temple_Scene");
        }

        if (isTouchingPizza1 && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("保存する位置: " + transform.position);
            PositionMemory.SavePosition(transform.position);
            SceneManager.LoadScene("Pizza1_Scene");
        }

        if (isTouchingOfice && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("保存する位置: " + transform.position);
            PositionMemory.SavePosition(transform.position);
            SceneManager.LoadScene("Company_Scene");
        }
    }
}