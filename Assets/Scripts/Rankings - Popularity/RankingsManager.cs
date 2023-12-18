using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RankingsManager : MonoBehaviour
{
    [Header("_SO")]
    [SerializeField] List<Rankings_SO> rankings_SO = new List<Rankings_SO>();
    List<CharacterSlot> tempRankings_SO = new List<CharacterSlot>();

    [Header("CharacterSlot")]
    [SerializeField] GameObject characterSlot_Parent;
    [SerializeField] GameObject characterSlot_Prefab;

    [Header("Tier Background")]
    [SerializeField] Color tier_Normal;
    [SerializeField] Color tier_Rare;
    [SerializeField] Color tier_Epic;
    [SerializeField] Color tier_Legendary;

    [Header("List")]
    [SerializeField] List<GameObject> characterSlotList = new List<GameObject>();

    [SerializeField] float timer = 5;
    float counter;
    int old_SO_Size = 0;


    //--------------------


    private void Start()
    {
        counter = timer;

        UpdateList();
    }
    private void Update()
    {
        counter -= Time.fixedDeltaTime;

        if (counter <= 0)
        {
            counter = timer;
            UpdateList();
        }
        else if (old_SO_Size != Get_SOListSize())
        {
            UpdateList();
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            UpdateList();
        }
    }


    //--------------------


    void UpdateList()
    {
        //Set new Old size for future comparisons
        old_SO_Size = Get_SOListSize();

        //Sort list basd on Popularity
        ResetAndBuildList();
    }

    void ResetAndBuildList()
    {
        //Destroy List
        ResetList(characterSlotList);

        //Build new list
        List<CharacterSlot> temp = BubbleSortByPopularity();
        BuildList(temp);
    }

    void ResetList(List<GameObject> list)
    {
        //Reset list
        for (int i = 0; i < list.Count; i++)
        {
            list[i].GetComponent<RankingsSlot>().SetRankingSlot("", 0, 0, tier_Normal);
        }

        //Add/Remove to list
        while (characterSlotList.Count < Get_SOListSize())
        {
            characterSlotList.Add(Instantiate(characterSlot_Prefab) as GameObject);
            characterSlotList[characterSlotList.Count - 1].transform.parent = characterSlot_Parent.transform;

            characterSlotList[characterSlotList.Count - 1].GetComponent<RankingsSlot>().SetRankingSlot("", 0, 0, tier_Normal);
        }
        while (characterSlotList.Count > Get_SOListSize())
        {
            characterSlotList[0].GetComponent<RankingsSlot>().DestroyObject();
            characterSlotList.RemoveAt(0);
        }
    }

    List<CharacterSlot> BubbleSortByPopularity()
    {
        //Add to list
        while (tempRankings_SO.Count < Get_SOListSize())
        {
            CharacterSlot temp = new CharacterSlot();

            tempRankings_SO.Add(temp);
        }
        while (tempRankings_SO.Count > Get_SOListSize())
        {
            tempRankings_SO.RemoveAt(0);
        }

        //Get correct stats
        int tempCount = 0;
        for (int i = 0; i < rankings_SO.Count; i++)
        {
            for (int j = 0; j < rankings_SO[i].characterRankings_List.Count; j++)
            {
                //tempRankings_SO.Add(rankings_SO[i].characterRankings_List[j]);

                tempRankings_SO[tempCount].name = rankings_SO[i].characterRankings_List[j].name;
                tempRankings_SO[tempCount].season = rankings_SO[i].characterRankings_List[j].season;
                tempRankings_SO[tempCount].popularity = rankings_SO[i].characterRankings_List[j].popularity;
                tempRankings_SO[tempCount].tier = rankings_SO[i].characterRankings_List[j].tier;

                tempCount++;
            }
        }

        //Sort the new List
        int n = tempRankings_SO.Count;
        bool swapped;

        do
        {
            swapped = false;

            for (int i = 1; i < n; i++)
            {
                if (tempRankings_SO[i - 1].popularity < tempRankings_SO[i].popularity)
                {
                    //Swap elements if they are in the wrong order
                    CharacterSlot temp = tempRankings_SO[i - 1];

                    tempRankings_SO[i - 1] = tempRankings_SO[i];
                    tempRankings_SO[i] = temp;

                    swapped = true;
                }
            }

            n--;
        }
        while (swapped);

        return tempRankings_SO;
    }

    void BuildList(List<CharacterSlot> updatedList)
    {
        characterSlot_Parent.GetComponent<RectTransform>().sizeDelta = new Vector2(characterSlot_Parent.GetComponent<RectTransform>().rect.width, 55 * updatedList.Count);

        for (int i = 0; i < updatedList.Count; i++)
        {
            #region Background Color
            Color newColor = new Color();

            switch (updatedList[i].tier)
            {
                case CharacterTier.None:
                    newColor = tier_Normal;
                    break;
                case CharacterTier.Normal:
                    newColor = tier_Normal;
                    break;
                case CharacterTier.Rare:
                    newColor = tier_Rare;
                    break;
                case CharacterTier.Epic:
                    newColor = tier_Epic;
                    break;
                case CharacterTier.Legendary:
                    newColor = tier_Legendary;
                    break;

                default:
                    break;
            }
            #endregion

            characterSlotList[i].GetComponent<RankingsSlot>().SetRankingSlot(updatedList[i].name, updatedList[i].season, updatedList[i].popularity, newColor);
        }
    }


    //--------------------


    int Get_SOListSize()
    {
        int temp = 0;

        for (int i = 0; i < rankings_SO.Count; i++)
        {
            for (int j = 0; j < rankings_SO[i].characterRankings_List.Count; j++)
            {
                temp++;
            }
        }

        return temp;
    }

}