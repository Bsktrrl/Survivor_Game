using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintManager : MonoBehaviour
{
    [SerializeField] Character_SO character_SO;
    [SerializeField] Button addTo_SO_Button;

    private void Update()
    {
        //Take Screanshot
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
        addTo_SO_Button.gameObject.SetActive(false);
        ScreenCapture.CaptureScreenshot("Temp" + ".png", 1);
        addTo_SO_Button.gameObject.SetActive(true);

        print("Take a Screenshot");
    }
    IEnumerator PrintAllCharacters()
    {
        addTo_SO_Button.gameObject.SetActive(false);

        for (int i = 0; i < character_SO.character_List.Count; i++)
        {
            CharacterCreator.instance.name = character_SO.character_List[i].name;
            CharacterCreator.instance.image = character_SO.character_List[i].image;
            CharacterCreator.instance.season = character_SO.character_List[i].season;
            CharacterCreator.instance.popularity = character_SO.character_List[i].popularity;
            CharacterCreator.instance.morale = character_SO.character_List[i].morale;
            CharacterCreator.instance.ability = character_SO.character_List[i].ability;

            CharacterCreator.instance.stat_Relationship = character_SO.character_List[i].Relationship;
            CharacterCreator.instance.stat_Charisma = character_SO.character_List[i].Charisma;
            CharacterCreator.instance.stat_Intuision = character_SO.character_List[i].Intuision;
            CharacterCreator.instance.stat_Persuation = character_SO.character_List[i].Persuation;
            CharacterCreator.instance.stat_Deception = character_SO.character_List[i].Deception;

            CharacterCreator.instance.stat_Dexterity = character_SO.character_List[i].Dexterity;
            CharacterCreator.instance.stat_Strength = character_SO.character_List[i].Strength;
            CharacterCreator.instance.stat_Puzzle = character_SO.character_List[i].Puzzle;
            CharacterCreator.instance.stat_Consentration = character_SO.character_List[i].Consentration;
            CharacterCreator.instance.stat_Endurance = character_SO.character_List[i].Endurance;

            CharacterCreator.instance.stat_Loyality = character_SO.character_List[i].Loyality;
            CharacterCreator.instance.stat_Strategic = character_SO.character_List[i].Strategic;
            CharacterCreator.instance.stat_SelfControl = character_SO.character_List[i].SelfControl;
            CharacterCreator.instance.stat_Advantages = character_SO.character_List[i].Advantages;
            CharacterCreator.instance.stat_Survival = character_SO.character_List[i].Survival;

            yield return new WaitForSeconds(0.1f);
            ScreenCapture.CaptureScreenshot(character_SO.character_List[i].name + ".png", 1);
            yield return new WaitForSeconds(0.1f);

            //print("Take a Screenshot: " + character_SO.character_List[i].name + ".png");
        }

        addTo_SO_Button.gameObject.SetActive(true);
    }
}
