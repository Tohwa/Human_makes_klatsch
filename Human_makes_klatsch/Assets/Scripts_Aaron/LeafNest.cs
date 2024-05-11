using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafNest : MonoBehaviour
{
    [SerializeField, Range(0.1f, 5f)]
    private float _timeUntilDeactivated = 1.0f;

    private Collider2D _collider;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            StartCoroutine(DeactivatePlatform());
    }

    private IEnumerator DeactivatePlatform()
    {
        // Play fancy leaf animation
        yield return new WaitForSeconds(_timeUntilDeactivated);

        //Destroy(_collider, _timeUntilDestroyed);
        this.gameObject.SetActive(false);
    }
}
