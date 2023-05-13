using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneMgr : MonoBehaviour
{
    public static SceneMgr inst;


    private void Awake(){
        inst = this;
    }

    private InventoryMgr3D inventoryMgr3D;
    public GameObject loadingScreen;
    public TextMeshProUGUI loadingScreenText;

    void Start()
    {
        inventoryMgr3D = InventoryMgr3D.inst;
    }

    public void LoadScene(){
        int sceneIndex = inventoryMgr3D.currLevel;
        loadingScreen.SetActive(true);
        if(!currLoading)
            StartCoroutine(LoadSceneAsynchronously(sceneIndex));
        
        if (sceneIndex == 4){
            loadingScreenText.text = "Traveling to Village";
        }else if(sceneIndex == 1){
            loadingScreenText.text = "Entering Easy Adventure";
        }else if(sceneIndex == 2){
            loadingScreenText.text = "Entering Hard Adventure";
        }else if(sceneIndex == 3){
            loadingScreenText.text = "Prepare Yourself for Battle";
        }
    }

    private AsyncOperation asyncLoad;
    public bool currLoading = false;
    IEnumerator LoadSceneAsynchronously(int sceneIndex)
    {
        if(!currLoading){
            asyncLoad = SceneManager.LoadSceneAsync((sceneIndex + 2), LoadSceneMode.Single);
            asyncLoad.allowSceneActivation = false;
            currLoading = true;
        }

        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
            }
            CameraMgr.inst.busy = !asyncLoad.isDone;
            yield return null;
        }

        OpenInventory();
        SceneManager.UnloadSceneAsync("GameBoard");
        asyncLoad.allowSceneActivation = true;

        CameraMgr.inst.busy = !asyncLoad.isDone;
        currLoading = false;
        yield return null;
    }

    public void OpenInventory(){
        SceneManager.LoadScene("GameBoard", LoadSceneMode.Additive);
    }
}
