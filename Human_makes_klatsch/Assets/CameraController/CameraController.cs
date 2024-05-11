using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// To do
// -> Var for camera rotation
// -> Get camera rotation at start
// -> Ensure camera rotation stays the same using Update

public class CameraController : MonoBehaviour
{
    // Saves the rotation
    private Quaternion _rotation;


    private void Start()
    {
        // Get rotation at start
        _rotation = transform.rotation;
    }

    private void Update()
    {
        // Make sure camera stays at rotation
        transform.rotation = _rotation;
    }
}
