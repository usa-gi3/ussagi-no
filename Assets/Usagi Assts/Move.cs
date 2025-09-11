using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    private bool isTouchingShop = false;
    private bool isTouchingVinyl = false;
    private bool isTouchingBar = false;

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


        if (other.gameObject.CompareTag("Bar1"))
        {
            isTouchingBar = true;
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

        if (other.gameObject.CompareTag("Bar1"))
        {
            isTouchingBar = false;
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
    }
}