using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSpriteSetter : MonoBehaviour
{
    GameObject player;
    Image texture;

    public Sprite noCracks;
    public Sprite oneCrack;
    public Sprite twoCracks;
    public Sprite threeCracks;
    public Sprite fourCracks;
    public Sprite brokenEgg;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Health");
        texture = player.GetComponent<Image>();
    }

    private void Update()
    {
        if (GameManager.Instance.GetPlayerHealth() == 4)
        {
            texture.sprite = noCracks;
        }
        else if (GameManager.Instance.GetPlayerHealth() == 3)
        {
            texture.sprite = oneCrack;
        }
        else if (GameManager.Instance.GetPlayerHealth() == 2)
        {
            texture.sprite = twoCracks;
        }
        else if (GameManager.Instance.GetPlayerHealth() == 1)
        {
            texture.sprite = threeCracks;
        }
        else if (GameManager.Instance.GetPlayerHealth() == 0)
        {
            texture.sprite = brokenEgg;
        }
    }
}
