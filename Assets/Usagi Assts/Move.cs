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
    private bool isTouchingmeid = false;

    private SEManager seManager; // ← SEManager参照用

    void Start()
    {
        // シーン内のSEManagerを探して参照する
        seManager = FindObjectOfType<SEManager>();
    }

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

        if (other.CompareTag("meid"))
        {
            isTouchingmeid = true;
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

        if (other.CompareTag("ofice"))
        {
            isTouchingOfice = false;
        }

        if (other.CompareTag("meid"))
        {
            isTouchingmeid = false;
        }
    }

    void Update()
    {
        if (isTouchingShop && Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("保存する位置: " + transform.position);
            //PositionMemory.SavePosition(transform.position);
            LoadSceneWithSE("Shop_Scene");
        }

        if (isTouchingVinyl && Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("保存する位置: " + transform.position);
            //PositionMemory.SavePosition(transform.position);
            LoadSceneWithSE("Vinyl_Scene");
        }

        if (isTouchingBar && Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("保存する位置: " + transform.position);
            //PositionMemory.SavePosition(transform.position);
            LoadSceneWithSE("Bar_Scene");
        }

        if (isTouchingTemple && Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("保存する位置: " + transform.position);
            //PositionMemory.SavePosition(transform.position);
            LoadSceneWithSE("Temple_Scene");
        }

        if (isTouchingPizza1 && Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("保存する位置: " + transform.position);
            //PositionMemory.SavePosition(transform.position);
            LoadSceneWithSE("Pizza1_Scene");
        }

        if (isTouchingOfice && Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("保存する位置: " + transform.position);
            //PositionMemory.SavePosition(transform.position);
            LoadSceneWithSE("Company_Scene");
        }

        if (isTouchingmeid && Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("保存する位置: " + transform.position);
            //PositionMemory.SavePosition(transform.position);
            LoadSceneWithSE("Maid_Scene");
        }
    }

    void LoadSceneWithSE(string sceneName)
    {
        Debug.Log("保存する位置: " + transform.position);
        PositionMemory.SavePosition(transform.position);

        // SEManager経由で効果音を鳴らす
        if (seManager != null)
        {
            seManager.PlaysceneChangeMoveSE();
        }

        // 少し待ってからシーンを切り替える（効果音が途中で切れないように）
        StartCoroutine(LoadSceneAfterDelay(sceneName, 0.3f));
    }

    System.Collections.IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}