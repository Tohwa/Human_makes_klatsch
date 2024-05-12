using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Get the sprite animator from game obj
        Animator animator = this.gameObject.GetComponent<Animator>();

        // If animator valid
        if (animator is not null)
        {
            // Play animation
            animator.SetTrigger("Wobble");
            Debug.Log(name + ": Animation triggered");
            return;
        }

        Debug.Log("animator is null");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Do sum ...
    }
}