using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usagi_S : MonoBehaviour
{

    public static int New_start=1;
    public InkController_ookami inkController;

    // Start is called before the first frame update
    void Start()
    {
        if (New_start == 1)
        {

            inkController.StartDialogue();
            New_start = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
