using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /// <summary>
    /// Target in scene, the camera is supposed to follow.
    /// </summary>
    [Tooltip("The target transform (in the scene) that the camera should follow.")]
    [SerializeField] private Transform _followTarget;


    /// <summary>
    /// Adjusts the cameras damping time.
    /// </summary>
    /// 
     [Tooltip("How fast the camera follows the target (the lower the value, the faster the camera).")]
     [SerializeField] private float _followSmoothness = 0.25f;



    // Private stuff
    private Vector3 _offset = new Vector3(0, 0, -10);
    private Vector3 _velocity = Vector3.zero;



    //! Gebunden an fixed tick interval in project settings !//
    private void FixedUpdate()
    {
        // Get the position of the target (+ offset)
        Vector3 targetPosition = _followTarget.position + _offset;

        // Fixed X axis
        //targetPosition.x = 0;

        // Move Camera to new follow position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _followSmoothness);
    }
}



// Source

// Smooth Damp: https://docs.unity3d.com/ScriptReference/Vector3.SmoothDamp.html
