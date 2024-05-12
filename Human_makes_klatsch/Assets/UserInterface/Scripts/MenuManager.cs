using UnityEngine;

public static class MenuManager
{

    public static bool IsMainInitialised { get; private set; }
    public static bool IsPauseInitialised { get; private set; }
    public static bool IsEndInitialised { get; private set; }


    public static GameObject  mainMenu, settingsMenu, settingsPauseMenu, creditsMenu, pauseMenu, winMenu, loseMenu;
     public static void init()
    {
        GameObject canvas = GameObject.Find("Canvas");
        GameObject Pausecanvas = GameObject.Find("PauseCanvas");
        GameObject EndCanvas = GameObject.Find("EndCanvas");

        mainMenu = canvas.transform.Find("MainMenu").gameObject;
        settingsMenu = canvas.transform.Find("Settings").gameObject;
        creditsMenu = canvas.transform.Find("Credits").gameObject;

        pauseMenu = Pausecanvas.transform.Find("PauseMenu").gameObject;
        settingsPauseMenu = Pausecanvas.transform.Find("PauseSettings").gameObject;

        winMenu = EndCanvas.transform.Find("Win").gameObject;
        loseMenu = EndCanvas.transform.Find("Lose").gameObject;

        IsMainInitialised = true;
        IsPauseInitialised = true;
        IsEndInitialised = true;
    }

    public static void OpenMainMenu(Menu menu, GameObject callingMainMenu)
    {
        if (!IsMainInitialised)
        {
            init();
        }

        switch(menu)
        {
            case Menu.MAIN_MENU:
                mainMenu.SetActive(true);
                break;
            case Menu.SETTINGS:
                settingsMenu.SetActive(true);
                break;
            case Menu.CREDITS:
                creditsMenu.SetActive(true);
                break;
        }

        callingMainMenu.SetActive(false);
    }

    public static void OpenPauseMenu(InGameMenu inGameMenu, GameObject callingPauseMenu)
    {
        if (!IsPauseInitialised)
        {
            init();
        }

        switch (inGameMenu)
        {
            case InGameMenu.PAUSE_MENU:
                pauseMenu.SetActive(true);
                break;
            case InGameMenu.PAUSE_SETTINGS:
                settingsPauseMenu.SetActive(true);
                break;
        }

        callingPauseMenu.SetActive(false);
    }

    public static void OpenEndMenu(EndSceneMenu endSceneMenu, GameObject callingEndMenu)
    {
        if (!IsEndInitialised)
        {
            init();
        }

        switch (endSceneMenu)
        {
            case EndSceneMenu.LOSE:
                loseMenu.SetActive(true);
                break;
            case EndSceneMenu.WIN:
                winMenu.SetActive(true);
                break;
        }

        callingEndMenu.SetActive(false);
    }
}
