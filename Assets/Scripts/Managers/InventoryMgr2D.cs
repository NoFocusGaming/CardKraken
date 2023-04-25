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

    public List<GameObject> inventoryPanels;
    public int inventorySize = 4;

    public Sprite CAT, STICK, TASTYSNACK, CAMPFIRE, ROCK, LEAF;
    public Sprite currSprite;

    public GameObject dragAndDropInstructs;

    public bool itemCard = false, companionCard = false;

    // Start is called before the first frame update
    void Start()
    {
        inventoryMgr3D = InventoryMgr3D.inst;
        companionMgr = CompanionMgr.inst;

        int index = 0;
        foreach (Sprite s in inventoryMgr3D.currInvSprites)
        {
            inventoryPanels[index].GetComponent<UnityEngine.UI.Image>().sprite = s;
            index++;
        }
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
        }else if(currentCard.CompareTag("Campfire"))
        {
            currSprite = CAMPFIRE; 
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

    public void addCardToInv(Card currCard)
    {
        inventoryMgr3D.currInventory.Add(currCard);
        inventoryMgr3D.currInvSprites.Add(currSprite);
        cardView.SetActive(false);
        inventoryPanels[(inventoryMgr3D.currInventory.Count - 1)].GetComponent<UnityEngine.UI.Image>().sprite = currSprite;
    }

    public void setCompanionSprite(){
        if(Utils.cardsOverlap(cardView.GetComponent<RectTransform>(), companionMgr.companion.GetComponent<RectTransform>()))
        {
            companionMgr.setCompanion(currSprite);
            cardView.SetActive(false);
            ControlMgr2D.inst.cardUsed = true;
            companionCard = false;
        }
    }
}
