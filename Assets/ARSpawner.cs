using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;
using UnityEngine.UI;

public class ARSpawner : MonoBehaviour
{
    public GameObject tomatoPrefab;
    public GameObject onionPrefab;
    public GameObject eggPrefab;

    public GameObject recipeCardPrefab;

    private ARRaycastManager raycastManager;
    private bool objectPlaced = false;

    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        if (objectPlaced) return;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            raycastManager.Raycast(Input.GetTouch(0).position, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon);

            if (hits.Count > 0)
            {
                var hitPose = hits[0].pose;

                string ingredient = PlayerPrefs.GetString("SelectedIngredient", "Tomato");

                GameObject modelToSpawn = null;

                switch (ingredient)
                {
                    case "Tomato":
                        modelToSpawn = tomatoPrefab;
                        break;
                    case "Onion":
                        modelToSpawn = onionPrefab;
                        break;
                    case "Egg":
                        modelToSpawn = eggPrefab;
                        break;
                }

                if (modelToSpawn != null)
                {
                    // Spawn the selected model
                    GameObject spawnedModel = Instantiate(modelToSpawn, hitPose.position, hitPose.rotation);
                    spawnedModel.AddComponent<Rigidbody>().mass = 0.3f;

                    // Spawn one shared recipe card prefab
                    GameObject card = Instantiate(recipeCardPrefab, hitPose.position + new Vector3(0.2f, 0, 0), hitPose.rotation);

                    // ?? Update text on the recipe card
                    UpdateRecipeCardText(card, ingredient);

                    objectPlaced = true;
                }
            }
        }
    }

    void UpdateRecipeCardText(GameObject card, string ingredient)
    {
        // Find Text components inside the prefab
        Text[] texts = card.GetComponentsInChildren<Text>();

        if (texts.Length >= 2)
        {
            if (ingredient == "Tomato")
            {
                texts[0].text = "?? Tomato Soup";
                texts[1].text = "Boil tomatoes, add salt & pepper, serve hot.";
            }
            else if (ingredient == "Onion")
            {
                texts[0].text = "?? Fried Onion Rings";
                texts[1].text = "Slice onions, coat with flour, fry until golden.";
            }
            else if (ingredient == "Egg")
            {
                texts[0].text = "?? Egg Omelette";
                texts[1].text = "Beat eggs, add spices, cook on pan until fluffy.";
            }
        }
    }
}
