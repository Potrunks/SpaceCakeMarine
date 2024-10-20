using Assets.Scripts;
using UnityEngine;

public class GameOverMenuSystem : MenuSystem
{
    public void QuitApplication()
    {
        Application.Quit();
    }

    public void DisplayGameOverMenu()
    {
        SetSelectedGameObject();
        gameObject.SetActive(true);
    }
}
