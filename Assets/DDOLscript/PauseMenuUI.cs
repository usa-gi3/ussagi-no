using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUI : MonoBehaviour
{

    [SerializeField]
    //　ポーズした時に表示するUIのプレハブ
    private GameObject pausemenuUIPrefab;
    //　ポーズUIのインスタンス
    private GameObject pausemenuUIInstance;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //メニューを開いている間ポーズ
            if (pausemenuUIInstance == null)
            {
                //メニューを開く
                pausemenuUIInstance = Instantiate(pausemenuUIPrefab);
                Time.timeScale = 0f; //ゲーム停止
            }
            else
            {
                //メニューを閉じる
                Destroy(pausemenuUIInstance);
                Time.timeScale = 1f; //ゲーム再開
            }
        }
    }

    // UIボタンから呼ぶ
    //着せ替え用
    public void OnSelectCharacter(int id)
    {
        GameManager.Instance.ChangeCharacter(id);
    }
}
