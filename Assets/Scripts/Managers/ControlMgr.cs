using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMgr : MonoBehaviour
{
    public CameraMgr cameraMgr;

    // Start is called before the first frame update
    void Start()
    {
        cameraMgr = CameraMgr.inst;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            cameraMgr.currCard.SetActive(true);
            SceneManager.UnloadSceneAsync("GameBoard");
        }
    }
}
