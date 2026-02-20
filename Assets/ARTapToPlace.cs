using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlace : MonoBehaviour
{
    public ARRaycastManager raycastManager; // drag AR Session Origin here
    public RecipeSpawner recipeSpawner;     // drag your RecipeSpawner GO here

    private readonly List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        if (Input.touchCount == 0) return;

        var touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began) return;

        if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
        {
            var pose = hits[0].pose;
            recipeSpawner.SpawnAt(pose.position);
        }
       
    }
}
