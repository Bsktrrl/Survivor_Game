using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrintCastaway : MonoBehaviour
{
    [SerializeField] Character_SO character_SO;

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

    void PrintScreen()
    {
        ScreenCapture.CaptureScreenshot("Temp" + ".png", 1);

        print("Take a Screenshot");
    }
    IEnumerator PrintAllCharacters()
    {
        CharacterCreator.Instance.isPrinting = true;

        for (int i = 0; i < character_SO.character_List.Count; i++)
        {
            CharacterCreator.Instance.SetDisplayedCard(i);

            yield return new WaitForSeconds(0.1f);
            ScreenCapture.CaptureScreenshot("Castaway - " + character_SO.character_List[i].name + ".png", 1);
            yield return new WaitForSeconds(0.1f);
        }

        CharacterCreator.Instance.isPrinting = false;
    }
}
