using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//InventoryMgr is designed to control the visuals and data of cards in player's inventory
public class InventoryMgr2D : MonoBehaviour
{
    public static InventoryMgr2D inst;
    private void Awake(){
        inst = this;
    }

    public GameObject cardView;
    private InventoryMgr3D inventoryMgr3D;
    private CompanionMgr companionMgr;

    public List<GameObject> inventoryPanels4;
    public List<GameObject> inventoryPanels5;
    public List<GameObject> currPanel;
    public int currInventoryIndex;

    public List<GameObject> invPanelsParentObjects;


    public Sprite CAT, STICK, TASTYSNACK, CAMPFIRE, ROCK, LEAF, BLANK;
    public Sprite currSprite;

    public GameObject dragAndDropInstructs;

    public GameObject GBC;

    public bool itemCard = false, companionCard = false, eventCard = false, effectCard = false;

    // Start is called before the first frame update
    void Start()
    {
        inventoryMgr3D = InventoryMgr3D.inst;
        companionMgr = CompanionMgr.inst;

        setInventory();
    }

    // Update is called once per frame
    void Update()
    {
        if(companionCard){
            dragAndDropInstructs.SetActive(true);
        }else{
            dragAndDropInstructs.SetActive(false);
        }
/*
        if ((Input.GetKeyDown(KeyCode.F)))
        {
            GBC.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            GBC.SetActive(false);
        }*/
    }

    //sets the child of the current card displaying in the center of the UI to currCard
    public void setCardView(GameObject currentCard)
    {
        itemCard = false;
        companionCard = false;
        eventCard = false;
        effectCard = false;

        if(currentCard.CompareTag("Cat"))
        {
            currSprite = CAT;
            companionCard = true;
        }else if(currentCard.CompareTag("Stick"))
        {
            currSprite = STICK;
            itemCard = true;   
        }else if(currentCard.CompareTag("TastySnack"))
        {
            currSprite = TASTYSNACK;
            effectCard = true;
        }else if(currentCard.CompareTag("Campfire"))
        {
            currSprite = CAMPFIRE; 
            eventCard = true;
        }else if(currentCard.CompareTag("Rock"))
        {
            currSprite = ROCK;   
            itemCard = true;
        }else if(currentCard.CompareTag("Leaf"))
        {
            currSprite = LEAF;  
            itemCard = true; 
        }

        cardView.GetComponent<UnityEngine.UI.Image>().sprite = currSprite;
    }

    public void setInventory()
    {
        currInventoryIndex = inventoryMgr3D.maxCards - 4;
        foreach(GameObject panelObject in invPanelsParentObjects)
            panelObject.SetActive(false);
        invPanelsParentObjects[currInventoryIndex].SetActive(true);

        if(inventoryMgr3D.maxCards == 4)
            currPanel = inventoryPanels4;
        else if(inventoryMgr3D.maxCards == 5)
            currPanel = inventoryPanels5;

        //on gameboard scene load - load sprites of all cards in curr inventory
        int index = 0;
        foreach (Sprite s in inventoryMgr3D.currInvSprites)
        {
            currPanel[index].GetComponent<UnityEngine.UI.Image>().sprite = s;
            index++;
        }
    }

    public void addCardToInv(Card currCard)
    {
        inventoryMgr3D.currInventory.Add(currCard);
        inventoryMgr3D.currInvSprites.Add(currSprite);
        cardView.SetActive(false);
        currPanel[(inventoryMgr3D.currInventory.Count - 1)].GetComponent<UnityEngine.UI.Image>().sprite = currSprite;

        if(currCard.card.CompareTag("Rock")){
            CardMgr3D.inst.leaf.SetActive(false);
            ControlMgr2D.inst.cardChoice = true;
        }else if(currCard.card.CompareTag("Leaf")){
            CardMgr3D.inst.rock.SetActive(false);
            ControlMgr2D.inst.cardChoice = true;
        }
    }

    public void setCompanionSprite(){
        companionMgr.setCompanion(currSprite);
        cardView.SetActive(false);
        ControlMgr2D.inst.cardUsed = true;
        companionCard = false;
    }

    public bool completeEventCard(int index){
        if(eventCard){
            if(inventoryMgr3D.currInventory[index-1].card.CompareTag("Stick")){
                cardView.SetActive(false);
                inventoryMgr3D.currInventory.RemoveAt(index-1);
                inventoryMgr3D.currInvSprites.RemoveAt(index-1);
                currPanel[index-1].GetComponent<UnityEngine.UI.Image>().sprite = BLANK;
                return true;
            }
        }

        return false;
    }
}
