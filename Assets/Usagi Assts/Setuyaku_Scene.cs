using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setuyaku_Scene : MonoBehaviour
{
    public GameObject One_Camera;
    public GameObject Two_Camera;
    public GameObject player; // プレイヤーを指定

    Vector3 Bar1Position = new Vector3(-5.845f, -5.756f, 3.512f);
    Vector3 Bar2Position = new Vector3(0.252f, 0.152f, 0.672f);

    private Collider triggeredObject;

    void Start()
    {
        One_Camera.SetActive(true);
        Two_Camera.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bar1") || other.CompareTag("Bar2"))
        {
            triggeredObject = other;
        }
    }

    void Update()
    {
        if (triggeredObject != null && Input.GetKeyDown(KeyCode.Space))
        {
            if (triggeredObject.CompareTag("Bar1"))
            {
                One_Camera.SetActive(true);
                Two_Camera.SetActive(false);
                player.transform.position = Bar1Position;
            }
            else if (triggeredObject.CompareTag("Bar2"))
            {
                One_Camera.SetActive(false);
                Two_Camera.SetActive(true);
                player.transform.position = Bar2Position;
            }

            triggeredObject = null;
        }
    }
}