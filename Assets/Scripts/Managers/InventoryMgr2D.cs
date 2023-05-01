using System;
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
    private CardMgr3D cardMgr3D;
    private CompanionMgr companionMgr;

    public List<GameObject> inventoryPanels4;
    public List<GameObject> inventoryPanels5;
    public List<GameObject> inventoryPanels6;
    public List<GameObject> inventoryPanels7;
    public List<GameObject> currPanel;
    public int currInventoryIndex;

    public List<GameObject> invPanelsParentObjects;


    public Sprite CAT, BLANK;
    public Sprite STICK, ROCK, LEAF, COOKIE, SHIELD, CANDLE, ROPE, FEATHER, AXE, NEEDLE, ARROWHEAD, DAGGER, MATCHES;
    public Sprite CAMPFIRE, SQUIRREL, SNAKE, TREEHOUSE, LAKE;
    public Sprite TASTYSNACK, IMPROVEDTECH, VENOM, FUNGUS;

    public Sprite currSprite;

    public GameObject dragAndDropInstructs;
    public GameObject qInstruct, rInstruct;

    public bool itemCard = false, companionCard = false, eventCard = false, effectCard = false;

    // Start is called before the first frame update
    void Start()
    {
        inventoryMgr3D = InventoryMgr3D.inst;
        companionMgr = CompanionMgr.inst;
        cardMgr3D = CardMgr3D.inst;

        setInventory();
        rInstruct.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(companionCard){
            dragAndDropInstructs.SetActive(true);
        }else{
            dragAndDropInstructs.SetActive(false);
        }
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
        }
        
        if(currentCard.CompareTag("Stick"))
        {
            currSprite = STICK;
            itemCard = true;   
        }else if(currentCard.CompareTag("Rock"))
        {
            currSprite = ROCK;   
            itemCard = true;
        }else if(currentCard.CompareTag("Leaf"))
        {
            currSprite = LEAF;  
            itemCard = true; 
        }else if(currentCard.CompareTag("Cookie"))
        {
            currSprite = COOKIE;
            itemCard = true;   
        }else if(currentCard.CompareTag("Shield"))
        {
            currSprite = SHIELD;
            itemCard = true;   
        }else if(currentCard.CompareTag("Candle"))
        {
            currSprite = CANDLE;
            itemCard = true;   
        }else if(currentCard.CompareTag("Rope"))
        {
            currSprite = ROPE;
            itemCard = true;   
        }else if(currentCard.CompareTag("Feather"))
        {
            currSprite = FEATHER;
            itemCard = true;   
        }else if(currentCard.CompareTag("Axe"))
        {
            currSprite = AXE;
            itemCard = true;   
        }else if(currentCard.CompareTag("Needle"))
        {
            currSprite = NEEDLE;
            itemCard = true;   
        }else if(currentCard.CompareTag("Arrowhead"))
        {
            currSprite = ARROWHEAD;
            itemCard = true;   
        }else if(currentCard.CompareTag("Dagger"))
        {
            currSprite = DAGGER;
            itemCard = true;   
        }else if(currentCard.CompareTag("Matches"))
        {
            currSprite = MATCHES;
            itemCard = true;   
        }

        if(currentCard.CompareTag("Campfire"))
        {
            currSprite = CAMPFIRE; 
            eventCard = true;
        }else if(currentCard.CompareTag("Squirrel"))
        {
            currSprite = SQUIRREL; 
            eventCard = true;
        }else if(currentCard.CompareTag("Snake"))
        {
            currSprite = SNAKE; 
            eventCard = true;
        }else if(currentCard.CompareTag("Treehouse"))
        {
            currSprite = TREEHOUSE; 
            eventCard = true;
        }else if(currentCard.CompareTag("Lake"))
        {
            currSprite = LAKE; 
            eventCard = true;
        }

        if(currentCard.CompareTag("TastySnack"))
        {
            currSprite = TASTYSNACK;
            effectCard = true;
        }else if(currentCard.CompareTag("ImprovedTechnique"))
        {
            currSprite = IMPROVEDTECH;
            effectCard = true;
        }else if(currentCard.CompareTag("Fungus"))
        {
            currSprite = FUNGUS;
            effectCard = true;
        }else if(currentCard.CompareTag("Venom"))
        {
            currSprite = VENOM;
            effectCard = true;
        }

        cardView.GetComponent<UnityEngine.UI.Image>().sprite = currSprite;

        if(eventCard && (inventoryMgr3D.currLevel != 0)){
            qInstruct.SetActive(false);
            rInstruct.SetActive(true);
        }
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
        else if(inventoryMgr3D.maxCards == 6)
            currPanel = inventoryPanels6;
        else if(inventoryMgr3D.maxCards == 7)
            currPanel = inventoryPanels7;

        //load sprites of all cards in curr inventory
        int index = 0;
        foreach (Sprite s in inventoryMgr3D.currInvSprites)
        {
            currPanel[index].GetComponent<UnityEngine.UI.Image>().sprite = s;
            index++;
        }
    }

    public void addCardToInv(Card currCard)
    {
        if(inventoryMgr3D.currInvTags.Count < inventoryMgr3D.maxCards){
            inventoryMgr3D.currInvTags.Add(currCard.card.tag);
            inventoryMgr3D.currInvSprites.Add(currSprite);
            inventoryMgr3D.currInvWeapon.Add(currCard.weapon);
            cardView.SetActive(false);
            currPanel[(inventoryMgr3D.currInvTags.Count - 1)].GetComponent<UnityEngine.UI.Image>().sprite = currSprite;

            if(inventoryMgr3D.currLevel == 0){
                if(currCard.card.CompareTag("Rock")){
                    CardMgr3D.inst.leaf.SetActive(false);
                    ControlMgr3D.inst.levelComplete = true;
                    inventoryMgr3D.tutorialComplete = true;
                }else if(currCard.card.CompareTag("Leaf")){
                    CardMgr3D.inst.rock.SetActive(false);
                    ControlMgr3D.inst.levelComplete = true;
                    inventoryMgr3D.tutorialComplete = true;
                }
            }else if(inventoryMgr3D.currLevel == 1){
                cardMgr3D.hideOtherItem();
            }
        }
    }

    public void setCompanionSprite(){
        companionMgr.setCompanion(currSprite);
        cardView.SetActive(false);
        ControlMgr2D.inst.cardUsed = true;
        companionCard = false;
    }

    public bool completeEventCard(int index){
        if(index > inventoryMgr3D.currInvTags.Count){
            ControlMgr2D.inst.eventFailed = true;
            return false;
        }

        bool complete = false;

        if(cardMgr3D.currCard.CompareTag("Campfire")){
            if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Stick")){
                ControlMgr2D.inst.snack = true;
                complete = true;
            }
        }else if(cardMgr3D.currCard.CompareTag("Squirrel")){
            if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Cookie")){
                ControlMgr2D.inst.technique = true;
                complete = true;
            }else if(inventoryMgr3D.currInvWeapon[index-1]){
                complete = true;
            }
        }else if(cardMgr3D.currCard.CompareTag("Snake")){
            if(inventoryMgr3D.currInvWeapon[index-1]){
                complete = true;
            }else{
                ControlMgr2D.inst.venom = true;
                complete = true;
            }
        }else if(cardMgr3D.currCard.CompareTag("Treehouse")){
            if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Rope")){
                ControlMgr2D.inst.axe = true;
                complete = true;
            }else{
                ControlMgr2D.inst.matches = true;
                complete = true;
            }
        }else if(cardMgr3D.currCard.CompareTag("Lake")){
            ControlMgr2D.inst.fungus = true;
            complete = true;
        }

        cardView.SetActive(!complete);
        inventoryMgr3D.currInvSprites.RemoveAt(index-1);
        inventoryMgr3D.currInvTags.RemoveAt(index-1);
        inventoryMgr3D.currInvWeapon.RemoveAt(index-1);
        currPanel[index-1].GetComponent<UnityEngine.UI.Image>().sprite = BLANK;

        if(inventoryMgr3D.currLevel == 1)
            CardMgr3D.inst.hideOtherEvent();

        ControlMgr2D.inst.eventFailed = !complete;

        return complete;
    }

    public void completeEffectCard()
    {
        if(cardMgr3D.currCard.CompareTag("TastySnack")){
            inventoryMgr3D.maxCards += 1;
            cardView.SetActive(false);
            setInventory();
            ControlMgr2D.inst.cardUsed = true;

            if(InventoryMgr3D.inst.currLevel == 1){
                inventoryMgr3D.levelOneComplete = true;
                ControlMgr3D.inst.levelComplete = true;
                cardMgr3D.clearSticks();
            }
        }
    }
}
