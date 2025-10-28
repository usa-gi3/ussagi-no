using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setumei : MonoBehaviour
{
    public GameObject Tyu1;
    public GameObject Tyu2;
    public GameObject Tyu3;
    public GameObject Tyu;
    int ClickCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        Tyu1.SetActive(true);
        Tyu2.SetActive(false);
        Tyu3.SetActive(false);
        Tyu.SetActive(true);

        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) // ç∂ÉNÉäÉbÉN
        {
            ClickCount++;
        }

        if (ClickCount == 0)
        {
            Tyu1.SetActive(true);
            Tyu2.SetActive(false);
            Tyu3.SetActive(false);

        } else if (ClickCount == 1) {

            Tyu1.SetActive(false);
            Tyu2.SetActive(true);

        }
        else if (ClickCount == 2) {

            Tyu2.SetActive(false);
            Tyu3.SetActive(true);


        } else if (ClickCount == 3)
        {

            Tyu3.SetActive(false);
            Tyu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

}