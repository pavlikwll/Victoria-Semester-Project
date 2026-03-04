using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject _currentMenu;
    
    [Header("MainMenuButtons")]
    public GameObject mainMenuContainer;
    public GameObject loadMenuContainer;
    public GameObject optionsMenuContainer;
    public GameObject controlsContainer;
    public GameObject startMenuContainer;
    public GameObject preloadMenuContainer;

    private void Awake()
    {
        _currentMenu = preloadMenuContainer;
    }

    public void OpenLoadMenu()
    {
        _currentMenu.SetActive(false);

        loadMenuContainer.SetActive(true);
        _currentMenu = loadMenuContainer;
    }

    public void OpenMainMenu()
    {
        _currentMenu.SetActive(false);
        
        mainMenuContainer.SetActive(true);
        _currentMenu = mainMenuContainer;
    }

    public void OpenStartMenu()
    {
        _currentMenu.SetActive(false);
        
        startMenuContainer.SetActive(true);
        _currentMenu = startMenuContainer;
    }

    public void OpenOptionsMenu()
    {
        _currentMenu.SetActive(false);
        
        optionsMenuContainer.SetActive(true);
        _currentMenu = optionsMenuContainer;
    }

    public void OpenControls()
    {
        _currentMenu.SetActive(false);
        
        controlsContainer.SetActive(true);
        _currentMenu = controlsContainer;
    }
}
