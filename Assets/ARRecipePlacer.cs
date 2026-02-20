using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ARRecipePlacer : MonoBehaviour
{
    public GameObject recipeCardPrefab;
    private ARRaycastManager raycastManager;
    private GameObject spawnedCard;

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                List<ARRaycastHit> hits = new List<ARRaycastHit>();
                if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = hits[0].pose;

                    if (spawnedCard == null)
                    {
                        spawnedCard = Instantiate(recipeCardPrefab, hitPose.position, hitPose.rotation);
                    }
                    else
                    {
                        spawnedCard.transform.position = hitPose.position;
                    }
                }
            }
        }
    }
}
