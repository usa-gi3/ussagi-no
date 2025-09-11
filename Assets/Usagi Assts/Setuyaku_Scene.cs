using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setuyaku_Scene : MonoBehaviour
{
    public GameObject One_Camera;
    public GameObject Two_Camera;
    Vector3 Bar1Position = new Vector3(-5.845f,-5.756f,3.512f);
    Vector3 Bar2Position = new Vector3(-41.661f,17.82f,-18.065f);




    // Start is called before the first frame update
    void Start()
    {
        One_Camera.SetActive(true);
        Two_Camera.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {

        if (Input.GetKey(KeyCode.Space))
        {


            if (other.CompareTag("Bar1"))
            {
                One_Camera.SetActive(true);
                Two_Camera.SetActive(false);
                transform.position = Bar1Position;

            }

            if (other.CompareTag("Bar2"))
            {
                One_Camera.SetActive(false);
                Two_Camera.SetActive(true);
                transform.position = Bar2Position;

            }

        }
    }






    // Update is called once per frame
    void Update()
    {
        


    }
}
