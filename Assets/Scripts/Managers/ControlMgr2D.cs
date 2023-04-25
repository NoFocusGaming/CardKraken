using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMgr2D : MonoBehaviour
{
    public static ControlMgr2D inst;
    private void Awake(){
        inst = this;
    }

    private ControlMgr3D controlMgr3D;
    private CameraMgr cameraMgr;
    private InventoryMgr2D inventoryMgr2D;
    private CardMgr2D cardMgr2D;

    public bool cardUsed = false;

    // Start is called before the first frame update
    void Start()
    {
        controlMgr3D = ControlMgr3D.inst;
        cameraMgr = CameraMgr.inst;
        inventoryMgr2D = InventoryMgr2D.inst;
        cardMgr2D = CardMgr2D.inst;

        inventoryMgr2D.setCardView(controlMgr3D.cardMgr3D.currCard);
        inventoryMgr2D.cardView.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //closing GameBoard scene on press of key 'Q'
        if(Input.GetKeyDown(KeyCode.Q)){
            if(!cardUsed)
                controlMgr3D.cardMgr3D.currCard.SetActive(true);

            SceneManager.UnloadSceneAsync("GameBoard");
        }

        if(inventoryMgr2D.itemCard && Input.GetKeyDown(KeyCode.E)){
            inventoryMgr2D.addCardToInv(controlMgr3D.cardMgr3D.currCard.GetComponent<Card>());
            cardUsed = true;
        }
    }
}
