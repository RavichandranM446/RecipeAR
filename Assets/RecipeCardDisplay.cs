using UnityEngine;
using TMPro;

public class RecipeCardDisplay : MonoBehaviour
{
    public TMP_Text titleText;
    public TMP_Text descriptionText;

    void Start()
    {
        // ? Read ingredient from PlayerPrefs instead of IngredientSelector
        string ingredient = PlayerPrefs.GetString("SelectedIngredient", "Tomato");

        if (ingredient == "Tomato")
        {
            titleText.text = "Tomato Soup ??";
            descriptionText.text = "Boil tomatoes, blend, and add salt & pepper.";
        }
        else if (ingredient == "Onion")
        {
            titleText.text = "Onion Curry ??";
            descriptionText.text = "Fry onions with garlic and add spices.";
        }
        else if (ingredient == "Egg")
        {
            titleText.text = "Egg Omelette ??";
            descriptionText.text = "Beat eggs, add onions & salt, and fry lightly.";
        }
    }
}
