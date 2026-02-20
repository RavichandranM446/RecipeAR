using UnityEngine;

public class BillboardToCamera : MonoBehaviour
{
    private Camera arCamera;

    void Start()
    {
        arCamera = Camera.main; // AR Camera automatically becomes main
    }

    void LateUpdate()
    {
        if (arCamera != null)
        {
            // Make the card face the AR camera
            transform.LookAt(arCamera.transform);
            transform.Rotate(0, 180, 0); // flip so text is readable (not mirrored)
        }
    }
}
