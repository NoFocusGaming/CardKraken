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
        Debug.Log("inside setCardView");

        if(currentCard.CompareTag("Cat"))
        {
            Debug.Log("inside cat comparetag");
            cardView.GetComponent<UnityEngine.UI.Image>().sprite = CAT;
        }
    }
}
