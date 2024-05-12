using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    [SerializeField] GameObject primaryMenu;
    [SerializeField] GameObject creditsMenu;

    [SerializeField] GameObject buttonReact;
    [SerializeField] GameObject button;

    [SerializeField] GameObject pauseButton;

    public void OnClick_BackMain()
    {
        StartCoroutine(DelayBackMain());
    }

    private IEnumerator DelayBackMain()
    {
        buttonReact.SetActive(true);
        yield return new WaitForSeconds(1f);
        primaryMenu.SetActive(true);
        creditsMenu.SetActive(false);

        yield return new WaitForSeconds(1f);
        buttonReact.SetActive(false);
    }
}
