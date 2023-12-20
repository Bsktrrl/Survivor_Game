using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintDailyTask : MonoBehaviour
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
        DailyTaskCreator.Instance.isScreenshoting = true;

        ScreenCapture.CaptureScreenshot("Temp" + ".png", 1);

        DailyTaskCreator.Instance.isScreenshoting = false;

        print("Take a Screenshot");
    }

    IEnumerator PrintAllCharacters()
    {
        DailyTaskCreator.Instance.isScreenshoting = true;

        for (int i = 0; i < DailyTaskCreator.Instance.dailyTask_SO.dailyTaskList.Count; i++)
        {
            print(i + " - Take a Screenshot: " + DailyTaskCreator.Instance.dailyTask_SO.dailyTaskList[i].name);

            DailyTaskCreator.Instance.BuildDailyTaskCard(i);

            yield return new WaitForSeconds(0.1f);
            ScreenCapture.CaptureScreenshot("Daily Task - " + DailyTaskCreator.Instance.dailyTask_SO.dailyTaskList[i].name + ".png", 1);
            yield return new WaitForSeconds(0.1f);
        }

        DailyTaskCreator.Instance.isScreenshoting = false;
    }
}
