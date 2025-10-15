using UnityEngine;

public class TalkTrigger : MonoBehaviour
{
    public InkController inkController;
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
            inkController.EndDialogue(); // ó£ÇÍÇΩÇÁUIÇï¬Ç∂ÇÈÅiîCà”Åj
        }
    }
}
