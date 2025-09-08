using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    private bool isTouchingShop = false;
    private bool isTouchingVinyl = false;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("�Փ˂����I�u�W�F�N�g�̃^�O: " + other.gameObject.tag);

        if (other.gameObject.CompareTag("shop"))
        {
            isTouchingShop = true;
        }

        if (other.gameObject.CompareTag("Vinyl"))
        {
            isTouchingVinyl = true;
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
    }

    void Update()
    {
        if (isTouchingShop && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("�ۑ�����ʒu: " + transform.position);
            PositionMemory.SavePosition(transform.position);
            SceneManager.LoadScene("Shop_Scene");
        }

        if (isTouchingVinyl && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("�ۑ�����ʒu: " + transform.position);
            PositionMemory.SavePosition(transform.position);
            SceneManager.LoadScene("Vinyl_Scene");
        }
    }
}