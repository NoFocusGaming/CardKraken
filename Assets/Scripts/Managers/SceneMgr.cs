using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMgr : MonoBehaviour
{
    public static SceneMgr inst;
    public GameObject loadingScreen;
    public Slider progressBar;
    private void Awake(){

        inst = this;
        DontDestroyOnLoad(gameObject);

    }

    private InventoryMgr3D inventoryMgr3D;

    // Start is called before the first frame update
    void Start()
    {
        inventoryMgr3D = InventoryMgr3D.inst;
    }

    // Update is called once per frame
    void Update()
    {
        // if kraken defeated, return to village, and display win text
        if (inventoryMgr3D.krakenDefeated){
            SceneManager.LoadScene("WinScreen", LoadSceneMode.Additive);
        }
    }

    public void LoadScene(){
        int sceneIndex = inventoryMgr3D.currLevel;
        loadingScreen.SetActive(true);
        StartCoroutine(LoadSceneAsynchronously(sceneIndex));
        /*
        if (sceneIndex == 1){
        SceneManager.LoadScene("Level1CardWorld", LoadSceneMode.Single);
        }else if(sceneIndex == 2){
        SceneManager.LoadScene("Level2CardWorld", LoadSceneMode.Single);
        }else if(sceneIndex == 3){
        SceneManager.LoadScene("BossCardWorld", LoadSceneMode.Single);
        }else if(sceneIndex == 4){
        SceneManager.LoadScene("VillageCardWorld", LoadSceneMode.Single);
        }
        */
}

    IEnumerator LoadSceneAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);
        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            progressBar.value = progressValue;
            yield return null;
        }
    }

    public void OpenInventory(){
        SceneManager.LoadScene("GameBoard", LoadSceneMode.Additive);
    }
}
