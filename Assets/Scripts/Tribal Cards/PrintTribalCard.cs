using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintTribalCard : MonoBehaviour
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
        TribalCardCreator.Instance.isScreenshoting = true;

        ScreenCapture.CaptureScreenshot("Temp" + ".png", 1);

        TribalCardCreator.Instance.isScreenshoting = false;

        print("Take a Screenshot");
    }

    IEnumerator PrintAllCharacters()
    {
        TribalCardCreator.Instance.isScreenshoting = true;

        for (int i = 0; i < TribalCardCreator.Instance.gameChanger_SO.gameChangerList.Count; i++)
        {
            print(i + " - Take a Screenshot: " + TribalCardCreator.Instance.gameChanger_SO.gameChangerList[i].name);

            TribalCardCreator.Instance.BuildEventCard(i);

            yield return new WaitForSeconds(0.1f);
            ScreenCapture.CaptureScreenshot("Tribal Card - " + TribalCardCreator.Instance.gameChanger_SO.gameChangerList[i].name + ".png", 1);
            yield return new WaitForSeconds(0.1f);
        }

        TribalCardCreator.Instance.isScreenshoting = false;
    }
}
