using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZoneBehaviour : MonoBehaviour
{
    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Egg"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.SetWinCondition();
        }
    }
}
