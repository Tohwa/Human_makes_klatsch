using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameralock : MonoBehaviour
{
    #region
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _background;
    [SerializeField] private Collider2D _playableArea;

    private float cameraHalfHeight;
    private float cameraHalfWidth;
    #endregion

    private void Start()
    {
        Camera _camera = GetComponent<Camera>();
        cameraHalfHeight = _camera.orthographicSize;
        cameraHalfWidth = _camera.orthographicSize * _camera.aspect;
    }

    private void Update()
    {
        if (_player == null && GameManager.Instance.GetPlayerHealth() > 0)
        {
            _player = GameObject.FindGameObjectWithTag("Egg");
            Debug.Log("Egg found!");
        }

        if (_background == null)
        {
            _background = GameObject.FindGameObjectWithTag("Background");
        }


    }
    private void LateUpdate()
    {
        if (GameManager.Instance.GetPlayerHealth() > 0)
        {
            Vector3 playerPosition = _player.transform.position;

            float clampedX = Mathf.Clamp(playerPosition.x, _playableArea.bounds.min.x + cameraHalfWidth, _playableArea.bounds.max.x - cameraHalfWidth);
            float clampedY = Mathf.Clamp(playerPosition.y, _playableArea.bounds.min.y + cameraHalfHeight, _playableArea.bounds.max.y - cameraHalfHeight);

            transform.position = new Vector3(clampedX, clampedY, transform.position.z);

        }
    }
}
