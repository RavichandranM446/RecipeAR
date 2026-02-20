using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneResetter : MonoBehaviour
{
    // Call this from the Reset button OnClick()
    public void ResetScene()
    {
        // Remove the selected ingredient key so menu will show again
        PlayerPrefs.DeleteKey("SelectedIngredient");
        PlayerPrefs.Save();

        // Reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
