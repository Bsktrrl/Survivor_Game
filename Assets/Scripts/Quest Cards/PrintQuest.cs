using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintQuest : MonoBehaviour
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
        QuestCreator.Instance.isScreenshoting = true;

        ScreenCapture.CaptureScreenshot("Temp" + ".png", 1);

        QuestCreator.Instance.isScreenshoting = false;

        print("Take a Screenshot");
    }

    IEnumerator PrintAllCharacters()
    {
        QuestCreator.Instance.isScreenshoting = true;

        for (int i = 0; i < QuestCreator.Instance.quest_SO.questList.Count; i++)
        {
            print(i + " - Take a Screenshot: " + QuestCreator.Instance.quest_SO.questList[i].name);

            QuestCreator.Instance.BuildQuestCard(i);

            yield return new WaitForSeconds(0.1f);
            ScreenCapture.CaptureScreenshot("Quest - " + QuestCreator.Instance.quest_SO.questList[i].name + ".png", 1);
            yield return new WaitForSeconds(0.1f);
        }

        QuestCreator.Instance.isScreenshoting = false;
    }
}
