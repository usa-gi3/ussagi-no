using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUI : MonoBehaviour
{

    [SerializeField]
    //�@�|�[�Y�������ɕ\������UI�̃v���n�u
    private GameObject pausemenuUIPrefab;
    //�@�|�[�YUI�̃C���X�^���X
    private GameObject pausemenuUIInstance;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //���j���[���J���Ă���ԃ|�[�Y
            if (pausemenuUIInstance == null)
            {
                pausemenuUIInstance = Instantiate(pausemenuUIPrefab);
                Time.timeScale = 0f; //�Q�[����~
            }
            else
            {
                Destroy(pausemenuUIInstance);
                Time.timeScale = 1f; //�Q�[���ĊJ
            }
        }
    }

    // UI�{�^������Ă�
    //�����ւ��p
    public void OnSelectCharacter(int id)
    {
        GameManager.Instance.ChangeCharacter(id);
    }
}
