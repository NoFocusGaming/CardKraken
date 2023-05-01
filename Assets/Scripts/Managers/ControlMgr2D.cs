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
    public bool eventFailed = false;

    public bool snack = false, technique = false, fungus = false, venom = false;
    public bool axe = false, matches = false;

    // Start is called before the first frame update
    void Start()
    {
        controlMgr3D = ControlMgr3D.inst;
        cameraMgr = CameraMgr.inst;
        inventoryMgr2D = InventoryMgr2D.inst;
        cardMgr2D = CardMgr2D.inst;
        cardUsed = false;
        completeEvent = false;
        snack = false;
        technique = false;
        fungus = false;
        venom = false;
        axe = false;
        matches = false;

        //on gameboard load - sets the card currently in view to match the one in gameboard
        if(controlMgr3D.cardPresent){
            inventoryMgr2D.setCardView(controlMgr3D.cardMgr3D.currCard);
            inventoryMgr2D.cardView.SetActive(true);
        }

        if(InventoryMgr3D.inst.currLevel == 0){
            if(inventoryMgr2D.itemCard && InventoryMgr3D.inst.currInvTags.Count == 0){
                CompanionMgr.inst.setDialogue(0);
            }

            if(inventoryMgr2D.eventCard){
                CompanionMgr.inst.setDialogue(1);
            }

            if(inventoryMgr2D.effectCard){
                CompanionMgr.inst.setDialogue(2);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //closing GameBoard scene on press of key 'Q'
        if(!inventoryMgr2D.eventCard && Input.GetKeyDown(KeyCode.Q)){
            if(controlMgr3D.cardPresent){
                if(!cardUsed){
                    controlMgr3D.cardMgr3D.currCard.SetActive(true);
                }else{
                    controlMgr3D.cardPresent = false;
                }
            }

            controlMgr3D.inventoryOpen = false;
            SceneManager.UnloadSceneAsync("GameBoard");
        }

        if((InventoryMgr3D.inst.currLevel != 0) && inventoryMgr2D.eventCard && Input.GetKeyDown(KeyCode.R)){
            InventoryMgr3D.inst.currLevel = 4;
            SceneManager.LoadScene("VillageCardWorld");
        }

        if((inventoryMgr2D.itemCard || inventoryMgr2D.effectCard) && Input.GetKeyDown(KeyCode.E)){
            if(!controlMgr3D.cardMgr3D.currCard.CompareTag("TastySnack")){
                inventoryMgr2D.addCardToInv(controlMgr3D.cardMgr3D.currCard.GetComponent<Card>());
                cardUsed = true;
            }
        }

        if(inventoryMgr2D.eventCard){
            if(Input.GetKeyDown(KeyCode.Alpha1)){
                completeEvent = inventoryMgr2D.completeEventCard(1);
            }else if(Input.GetKeyDown(KeyCode.Alpha2)){
                completeEvent = inventoryMgr2D.completeEventCard(2);
            }else if(Input.GetKeyDown(KeyCode.Alpha3)){
                completeEvent = inventoryMgr2D.completeEventCard(3);
            }else if(Input.GetKeyDown(KeyCode.Alpha4)){
                completeEvent = inventoryMgr2D.completeEventCard(4);
            }
            cardUsed = completeEvent;
        }

        if(completeEvent){
            if(snack){
                controlMgr3D.cardMgr3D.tastySnack.SetActive(true);
                
                if(InventoryMgr3D.inst.currLevel == 1)
                    controlMgr3D.cardMgr3D.tastySnack1.SetActive(true);
            }

            if(technique)
                controlMgr3D.cardMgr3D.improvedTechnique.card.SetActive(true);

            if(venom)
                controlMgr3D.cardMgr3D.venom.card.SetActive(true);

            if(axe)
                controlMgr3D.cardMgr3D.axe.card.SetActive(true);

            if(matches)
                controlMgr3D.cardMgr3D.matches.card.SetActive(true);

            if(fungus)
                controlMgr3D.cardMgr3D.fungus.card.SetActive(true);

            controlMgr3D.inventoryOpen = false;
            SceneManager.UnloadSceneAsync("GameBoard");
        }

        if(eventFailed){
            InventoryMgr3D.inst.wipeInventory();
            InventoryMgr3D.inst.currLevel = 4;
            SceneManager.LoadScene("VillageCardWorld");
        }

        if(inventoryMgr2D.effectCard && Input.GetKeyDown(KeyCode.F)){
            inventoryMgr2D.completeEffectCard();
        }

        if(cardUsed){
            CompanionMgr.inst.removeDialogue();
        }
    }
}
