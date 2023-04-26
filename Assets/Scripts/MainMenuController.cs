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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    //add these once all levels are implemented
    /*
    public void loadLevel1()
    {
        SceneManager.LoadScene(1);
    }
    public void loadLevel2()
    {
        SceneManager.LoadScene(3);
    }
    public void loadLevel3()
    {
        SceneManager.LoadScene(4);
    }
    public void loadLevel4()
    {
        SceneManager.LoadScene(5);
    }
    */
}
