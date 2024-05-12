using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpriteSetter : MonoBehaviour
{
    GameObject player;
    SpriteRenderer spriteRenderer;

    public Sprite noCracks;
    public Sprite oneCrack;
    public Sprite twoCracks;
    public Sprite threeCracks;
    public Sprite fourCracks;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Egg");
        spriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(GameManager.Instance.GetPlayerHealth() == 4)
        {
            spriteRenderer.sprite = noCracks;
        }
        else if(GameManager.Instance.GetPlayerHealth() == 3)
        {
            spriteRenderer.sprite = oneCrack;
        }
        else if (GameManager.Instance.GetPlayerHealth() == 2)
        {
            spriteRenderer.sprite = twoCracks;
        }
        else if (GameManager.Instance.GetPlayerHealth() == 1)
        {
            spriteRenderer.sprite = threeCracks;
        }
        else if (GameManager.Instance.GetPlayerHealth() == 0)
        {
            GameManager.Instance.SetLooseCondition();
            Destroy(player);
        }
    }
}
