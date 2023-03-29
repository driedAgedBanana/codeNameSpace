using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptScreen : MonoBehaviour
{
    public Toggle fullScreenTog, vsyncTog;
    // Start is called before the first frame update
    void Start()
    {
        fullScreenTog.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
        {
            vsyncTog.isOn = true;
        }
        else
        {
            vsyncTog.isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
