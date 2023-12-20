using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintChallenges : MonoBehaviour
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
        ChallengeCreator.Instance.isScreenshoting = true;

        ScreenCapture.CaptureScreenshot("Temp" + ".png", 1);

        ChallengeCreator.Instance.isScreenshoting = false;

        print("Take a Screenshot");
    }

    IEnumerator PrintAllCharacters()
    {
        ChallengeCreator.Instance.isScreenshoting = true;

        for (int i = 0; i < ChallengeCreator.Instance.challenges_SO.requirementSlotList.Count; i++)
        {
            print(i + " - Take a Screenshot: " + ChallengeCreator.Instance.challenges_SO.requirementSlotList[i].name);

            ChallengeCreator.Instance.BuildChallengeCard(i);

            yield return new WaitForSeconds(0.1f);
            ScreenCapture.CaptureScreenshot(ChallengeCreator.Instance.challenges_SO.requirementSlotList[i].name + ".png", 1);
            yield return new WaitForSeconds(0.1f);
        }

        ChallengeCreator.Instance.isScreenshoting = false;
    }
}
