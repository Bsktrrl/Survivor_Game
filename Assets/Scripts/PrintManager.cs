using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintManager : MonoBehaviour
{

    private void Update()
    {
        //Take Screanshot
        if (Input.GetKeyDown(KeyCode.S))
        {
            PrintScreen();
        }
    }

    void PrintScreen()
    {
        ScreenCapture.CaptureScreenshot("Temp" + ".png", 1);

        print("Take a Screenshot");
    }
}
