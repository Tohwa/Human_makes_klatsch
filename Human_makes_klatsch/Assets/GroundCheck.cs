using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private PlayerController jumpRdy;
    public bool _isGrounded = false;
    public bool IsGrounded { get => _isGrounded; set => _isGrounded = value; }

    private Collider2D _collider2D;


    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();

        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        IsGrounded = true;
        //jumpRdy = true;
    }
}
