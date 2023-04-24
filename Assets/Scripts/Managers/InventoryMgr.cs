using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//InventoryMgr is designed to control the visuals and data of cards in player's inventory
public class InventoryMgr : MonoBehaviour
{
    public static InventoryMgr inst;
    private void Awake(){
        inst = this;
    }

    public List<Card> currInventory;
    public GameObject cardView;
    public int inventorySize = 4;

    public Sprite CAT, STICK, TASTYSNACK, CAMPFIRE, ROCK, LEAF;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //sets the child of the current card displaying in the center of the UI to currCard
    public void setCardView(GameObject currentCard)
    {
        if(currentCard.CompareTag("Cat"))
        {
            cardView.GetComponent<UnityEngine.UI.Image>().sprite = CAT;
        }else if(currentCard.CompareTag("Stick"))
        {
            cardView.GetComponent<UnityEngine.UI.Image>().sprite = STICK;   
        }else if(currentCard.CompareTag("TastySnack"))
        {
            cardView.GetComponent<UnityEngine.UI.Image>().sprite = TASTYSNACK;   
        }else if(currentCard.CompareTag("Campfire"))
        {
            cardView.GetComponent<UnityEngine.UI.Image>().sprite = CAMPFIRE;   
        }else if(currentCard.CompareTag("Rock"))
        {
            cardView.GetComponent<UnityEngine.UI.Image>().sprite = ROCK;   
        }else if(currentCard.CompareTag("Leaf"))
        {
            cardView.GetComponent<UnityEngine.UI.Image>().sprite = LEAF;   
        }
    }
}
