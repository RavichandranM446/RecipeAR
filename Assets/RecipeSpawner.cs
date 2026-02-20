using UnityEngine;

public class RecipeSpawner : MonoBehaviour
{
    [Header("3D Models")]
    public GameObject tomatoModel;
    public GameObject onionModel;
    public GameObject eggModel;

    [Header("Recipe Card Prefabs (World Space)")]
    public GameObject tomatoCardPrefab;
    public GameObject onionCardPrefab;
    public GameObject eggCardPrefab;

    [Header("Placement")]
    public Vector3 cardOffset = new Vector3(0.2f, 0.0f, 0.0f); // card beside model
    public float modelDropOffsetY = 0.05f;                      // start slightly above plane

    public void SpawnAt(Vector3 position)
    {
        // read the latest selection every time
        string ingredient = PlayerPrefs.GetString("SelectedIngredient", "Tomato");
        Debug.Log("Spawning for: " + ingredient);

        GameObject modelPrefab = null;
        GameObject cardPrefab = null;

        switch (ingredient)
        {
            case "Tomato":
                modelPrefab = tomatoModel;
                cardPrefab = tomatoCardPrefab;
                break;
            case "Onion":
                modelPrefab = onionModel;
                cardPrefab = onionCardPrefab;
                break;
            case "Egg":
                modelPrefab = eggModel;
                cardPrefab = eggCardPrefab;
                break;
            default:
                modelPrefab = tomatoModel;
                cardPrefab = tomatoCardPrefab;
                break;
        }

        // spawn model (with small drop)
        if (modelPrefab != null)
        {
            var spawnedModel = Instantiate(
                modelPrefab,
                position + new Vector3(0, modelDropOffsetY, 0),
                Quaternion.identity
            );
            var rb = spawnedModel.AddComponent<Rigidbody>();
            rb.mass = 0.3f;
        }

        // spawn matching recipe card
        if (cardPrefab != null)
        {
            Instantiate(
                cardPrefab,
                position + cardOffset,
                Quaternion.identity
            );
        }
    }
}
