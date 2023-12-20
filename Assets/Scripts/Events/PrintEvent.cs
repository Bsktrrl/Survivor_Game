using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintEvent : MonoBehaviour
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
        EventCreator.Instance.isScreenshoting = true;

        ScreenCapture.CaptureScreenshot("Temp" + ".png", 1);

        EventCreator.Instance.isScreenshoting = false;

        print("Take a Screenshot");
    }

    IEnumerator PrintAllCharacters()
    {
        EventCreator.Instance.isScreenshoting = true;

        for (int i = 0; i < EventCreator.Instance.event_SO.eventList.Count; i++)
        {
            print(i + " - Take a Screenshot: " + EventCreator.Instance.event_SO.eventList[i].name);

            EventCreator.Instance.BuildEventCard(i);

            yield return new WaitForSeconds(0.1f);
            ScreenCapture.CaptureScreenshot("Event - " + EventCreator.Instance.event_SO.eventList[i].name + ".png", 1);
            yield return new WaitForSeconds(0.1f);
        }

        EventCreator.Instance.isScreenshoting = false;
    }
}
