using UnityEngine;

public class IngredientSelector : MonoBehaviour
{
    [Header("Optional Settings")]
    public GameObject ingredientMenu; // Assign your IngredientMenu Canvas here (for clarity)

    public void SelectIngredient(string ingredient)
    {
        // ? Save the selected ingredient
        PlayerPrefs.SetString("SelectedIngredient", ingredient);
        PlayerPrefs.Save();

        Debug.Log("Selected Ingredient: " + ingredient);

        // ? Optional: hide the menu (make sure it’s assigned in Inspector)
        if (ingredientMenu != null)
        {
            ingredientMenu.SetActive(false);
        }
        else
        {
            // if this script itself is on the IngredientMenu GameObject
            gameObject.SetActive(false);
        }
    }
}
