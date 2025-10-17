using UnityEngine;
using UnityEngine.UI;

public class Map_UI : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject menuPanel;
    public Image[] imageDisplays; // ������Image�R���|�[�l���g

    [Header("Sprites")]
    public Sprite[] imageList;

    private int currentIndex = -1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            menuPanel.SetActive(!menuPanel.activeSelf);
        }
    }

    public void ShowImageByIndex(int index)
    {
        if (index >= 0 && index < imageList.Length && index < imageDisplays.Length)
        {
            // �����摜���\������Ă���ꍇ�͔�\���ɂ���
            if (currentIndex == index && imageDisplays[index].gameObject.activeSelf)
            {
                imageDisplays[index].gameObject.SetActive(false);
                currentIndex = -1;
                return;
            }

            // ���ׂẲ摜���\���ɂ���
            for (int i = 0; i < imageDisplays.Length; i++)
            {
                imageDisplays[i].gameObject.SetActive(false);
            }

            // �I�΂ꂽ�摜�����\������
            imageDisplays[index].sprite = imageList[index];
            imageDisplays[index].gameObject.SetActive(true);
            currentIndex = index;
        }
    }
}