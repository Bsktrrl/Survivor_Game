using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class CharacterCreator : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] int morale;

    [Header("Morale_Track")]
    [SerializeField] Image morale_Track;
    [SerializeField] Sprite morale_1;
    [SerializeField] Sprite morale_2;
    [SerializeField] Sprite morale_3;
    [SerializeField] Sprite morale_4;
    [SerializeField] Sprite morale_5;
    [SerializeField] Sprite morale_6;
    [SerializeField] Sprite morale_7;
    [SerializeField] Sprite morale_8;
    [SerializeField] Sprite morale_9;
    [SerializeField] Sprite morale_10;


    //--------------------


    private void Update()
    {
        //Set Morale_Track
        switch (morale)
        {
            case 0:
                morale_Track.sprite = null;
                break;
            case 1:
                morale_Track.sprite = morale_1;
                break;
            case 2:
                morale_Track.sprite = morale_2;
                break;
            case 3:
                morale_Track.sprite = morale_3;
                break;
            case 4:
                morale_Track.sprite = morale_4;
                break;
            case 5:
                morale_Track.sprite = morale_5;
                break;
            case 6:
                morale_Track.sprite = morale_6;
                break;
            case 7:
                morale_Track.sprite = morale_7;
                break;
            case 8:
                morale_Track.sprite = morale_8;
                break;
            case 9:
                morale_Track.sprite = morale_9;
                break;
            case 10:
                morale_Track.sprite = morale_10;
                break;
            default:
                break;
        }
    }
}
