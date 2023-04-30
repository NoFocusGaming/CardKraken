using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
  public GameObject levelSelectMenu;
  public AudioClip buttonClickSound;
  private AudioSource audioSource;

    private void Start()
    {
        levelSelectMenu.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        audioSource.PlayOneShot(buttonClickSound);
    }

    public void loadTutorial()
    {
        SceneManager.LoadScene("TutorialCardWorld");
        audioSource.PlayOneShot(buttonClickSound);
    }

    public void loadVillage()
    {
        SceneManager.LoadScene("VillageCardWorld");
        audioSource.PlayOneShot(buttonClickSound);
    }

    public void loadLevel1()
    {
        SceneManager.LoadScene("Level1CardWorld");
    }

    public void loadLevel2()
    {
        SceneManager.LoadScene("Level2CardWorld");
        audioSource.PlayOneShot(buttonClickSound);
    }

    public void loadBoss()
    {
        SceneManager.LoadScene("BossCardWorld");
        audioSource.PlayOneShot(buttonClickSound);
    }

    public void quit()
    {
        Application.Quit();
    }

}
