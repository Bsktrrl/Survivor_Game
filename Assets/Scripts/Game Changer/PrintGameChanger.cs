using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintGameChanger : MonoBehaviour
{


    //--------------------


    private void Update()
    {
        //Take Screenshot
        if (Input.GetKeyDown(KeyCode.S))
        {
            PrintScreen();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(PrintAllCharacters());
        }
    }


    //--------------------


    void PrintScreen()
    {
        GameChangerCreator.Instance.isScreenshoting = true;

        ScreenCapture.CaptureScreenshot("Temp" + ".png", 1);

        GameChangerCreator.Instance.isScreenshoting = false;

        print("Take a Screenshot");
    }

    IEnumerator PrintAllCharacters()
    {
        GameChangerCreator.Instance.isScreenshoting = true;

        for (int i = 0; i < GameChangerCreator.Instance.gameChanger_SO.gameChangerList.Count; i++)
        {
            print(i + " - Take a Screenshot: " + GameChangerCreator.Instance.gameChanger_SO.gameChangerList[i].name);

            GameChangerCreator.Instance.BuildEventCard(i);

            yield return new WaitForSeconds(0.1f);
            ScreenCapture.CaptureScreenshot("Game Changer - " + GameChangerCreator.Instance.gameChanger_SO.gameChangerList[i].name + ".png", 1);
            yield return new WaitForSeconds(0.1f);
        }

        GameChangerCreator.Instance.isScreenshoting = false;
    }
}
