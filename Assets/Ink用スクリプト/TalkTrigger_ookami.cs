using UnityEngine;

public class TalkTrigger_ookami : MonoBehaviour
{
    public InkController_ookami inkController;
    private bool isPlayerNear = false;

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            inkController.StartDialogue();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            inkController.EndDialogue(); // ���ꂽ��UI�����i�C�Ӂj
        }
    }

    public void DestroySelf()
    {
        Debug.Log($"{gameObject.name} ���폜���܂��B");
        if (inkController != null)
        {
            inkController.EndDialogue();
        }

        Destroy(gameObject);
    }
}
