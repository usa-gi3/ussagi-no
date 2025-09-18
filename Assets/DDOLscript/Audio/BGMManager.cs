using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private static BGMManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ƒV[ƒ“‚ğØ‚è‘Ö‚¦‚Ä‚à”jŠü‚³‚ê‚È‚¢
        }
        else
        {
            Destroy(gameObject); // 2‚Â–Ú‚ª¶¬‚³‚ê‚È‚¢‚æ‚¤‚É”jŠü
        }
    }
}

