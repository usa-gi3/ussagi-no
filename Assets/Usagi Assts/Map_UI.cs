using UnityEngine;
using UnityEngine.UI;

public class Map_UI : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject menuPanel;
    public Image[] imageDisplays; // 複数のImageコンポーネント

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
            // 同じ画像が表示されている場合は非表示にする
            if (currentIndex == index && imageDisplays[index].gameObject.activeSelf)
            {
                imageDisplays[index].gameObject.SetActive(false);
                currentIndex = -1;
                return;
            }

            // すべての画像を非表示にする
            for (int i = 0; i < imageDisplays.Length; i++)
            {
                imageDisplays[i].gameObject.SetActive(false);
            }

            // 選ばれた画像だけ表示する
            imageDisplays[index].sprite = imageList[index];
            imageDisplays[index].gameObject.SetActive(true);
            currentIndex = index;
        }
    }
}