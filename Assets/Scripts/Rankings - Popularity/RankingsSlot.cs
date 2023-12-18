using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RankingsSlot : MonoBehaviour
{
    [Header("TextMeshProUGUI")]
    public TextMeshProUGUI name_Placeholder;
    public TextMeshProUGUI name_Text;
    public TextMeshProUGUI season_Placeholder;
    public TextMeshProUGUI season_Text;
    public TextMeshProUGUI popularity_Placeholder;
    public TextMeshProUGUI popularity_Text;

    [Header("Background")]
    [SerializeField] Image background;
    [SerializeField] Image background_NameInput;
    [SerializeField] Image background_SeasonInput;
    [SerializeField] Image background_PopularityInput;


    //--------------------


    public void SetRankingSlot(string _name, int _season, int _popularity, Color _color)
    {
        name_Placeholder.text = _name;
        name_Text.text = _name;
        season_Placeholder.text = _season.ToString();
        season_Text.text = _season.ToString();
        popularity_Placeholder.text = _popularity.ToString();
        popularity_Text.text = _popularity.ToString();

        background.color = _color;
        background_NameInput.color = _color;
        background_SeasonInput.color = _color;
        background_PopularityInput.color = _color;
    }

    public void DestroyObject()
    {
        DestroyImmediate(gameObject);
    }
}
