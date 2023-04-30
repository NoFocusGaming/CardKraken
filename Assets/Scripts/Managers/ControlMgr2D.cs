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
    public bool completeEvent = false;
    public bool cardChoice = false;

    // Start is called before the first frame update
    void Start()
    {
        controlMgr3D = ControlMgr3D.inst;
        cameraMgr = CameraMgr.inst;
        inventoryMgr2D = InventoryMgr2D.inst;
        cardMgr2D = CardMgr2D.inst;
        cardUsed = false;
        completeEvent = false;

        //on gameboard load - sets the card currently in view to match the one in gameboard
        if(controlMgr3D.cardPresent){
            inventoryMgr2D.setCardView(controlMgr3D.cardMgr3D.currCard);
            inventoryMgr2D.cardView.SetActive(true);
        }

        if(inventoryMgr2D.itemCard && InventoryMgr3D.inst.currInventory.Count == 0){
            CompanionMgr.inst.setDialogue(0);
        }

        if(inventoryMgr2D.eventCard){
            CompanionMgr.inst.setDialogue(1);
        }

        if(inventoryMgr2D.effectCard){
            CompanionMgr.inst.setDialogue(2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //closing GameBoard scene on press of key 'Q'
        if(Input.GetKeyDown(KeyCode.Q)){
            if(controlMgr3D.cardPresent){
                if(!cardUsed){
                    controlMgr3D.cardMgr3D.currCard.SetActive(true);
                }else{
                    controlMgr3D.cardPresent = false;
                }

                if(completeEvent)
                    controlMgr3D.cardMgr3D.tastySnack.SetActive(true);
            }

            controlMgr3D.inventoryOpen = false;
            SceneManager.UnloadSceneAsync("GameBoard");
        }

        if(inventoryMgr2D.itemCard && Input.GetKeyDown(KeyCode.E)){
            inventoryMgr2D.addCardToInv(controlMgr3D.cardMgr3D.currCard.GetComponent<Card>());
            cardUsed = true;
        }

        if(inventoryMgr2D.eventCard){
            if(Input.GetKeyDown(KeyCode.Alpha1)){
                completeEvent = inventoryMgr2D.completeEventCard(1);
            }else if(Input.GetKeyDown(KeyCode.Alpha2)){
                completeEvent = inventoryMgr2D.completeEventCard(2);
            }else if(Input.GetKeyDown(KeyCode.Alpha3)){
                completeEvent = inventoryMgr2D.completeEventCard(3);
            }
            cardUsed = completeEvent;
        }

        if(inventoryMgr2D.effectCard && Input.GetKeyDown(KeyCode.F)){
            InventoryMgr3D.inst.maxCards += 1;
            inventoryMgr2D.cardView.SetActive(false);
            inventoryMgr2D.setInventory();
            cardUsed = true;
        }

        if(cardUsed){
            CompanionMgr.inst.removeDialogue();
        }
    }
}
