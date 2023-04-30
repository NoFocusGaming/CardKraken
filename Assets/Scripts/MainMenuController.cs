using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
  public GameObject levelSelectMenu;

    private void Start()
    {
        levelSelectMenu.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void loadTutorial()
    {
        SceneManager.LoadScene("TutorialCardWorld");
    }

    public void loadVillage()
    {
        SceneManager.LoadScene("VillageCardWorld");
    }

    public void loadLevel1()
    {
        SceneManager.LoadScene("Level1CardWorld");
    }

    public void loadLevel2()
    {
        SceneManager.LoadScene("Level2CardWorld");
    }

    public void loadBoss()
    {
        SceneManager.LoadScene("BossCardWorld");
    }

    public void quit()
    {
        Application.Quit();
    }

}
