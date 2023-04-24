using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMgr2D : MonoBehaviour
{
    private ControlMgr3D controlMgr3D;
    private InventoryMgr inventoryMgr;
    private CardMgr2D cardMgr2D;

    // Start is called before the first frame update
    void Start()
    {
        controlMgr3D = ControlMgr3D.inst;
        inventoryMgr = InventoryMgr.inst;
        cardMgr2D = CardMgr2D.inst;
        
        inventoryMgr.setCardView(controlMgr3D.cardMgr3D.currCard);
    }

    // Update is called once per frame
    void Update()
    {
        //closing GameBoard scene on press of key 'Q'
        if(Input.GetKeyDown(KeyCode.Q)){
            controlMgr3D.cardMgr3D.currCard.SetActive(true);
            SceneManager.UnloadSceneAsync("GameBoard");
        }
    }
}
