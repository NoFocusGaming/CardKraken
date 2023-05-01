using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
CardMgr3D is a child of CardMgr class
Designed to manage all cards in 3D (CardWorld) scene
*/
public class CardMgr3D : MonoBehaviour
{
    public static CardMgr3D inst;
    private void Awake(){
        inst = this;
    }

    public List<Card> allItemCards;
    public List<Card> allEventCards;
    public Card improvedTechnique, venom, fungus, axe, matches;

    public List<GameObject> itemSlots;
    public List<GameObject> eventSlots;
    public List<GameObject> effectSlots;
    public GameObject currCard;  
    public GameObject tastySnack, tastySnack1;
    public GameObject stick0, stick1, leaf, rock;
    public GameObject campfire0, campfire1;

    // Start is called before the first frame update
    void Start()
    {
        if(InventoryMgr3D.inst.currLevel == 1){
            foreach(GameObject itemSlot in itemSlots){
                int random = Random.Range(1, allItemCards.Count);
                allItemCards[(random - 1)].transform.SetParent(itemSlot.transform, false);
                allItemCards[(random -1)].card.SetActive(true);
                allItemCards.RemoveAt(random - 1);
            }  

            int index = 0;
            foreach(GameObject eventSlot in eventSlots){
                int random = Random.Range(1, allEventCards.Count);
                allEventCards[(random - 1)].transform.SetParent(eventSlot.transform, false);
                allEventCards[(random -1)].card.SetActive(true);
                
                if(allEventCards[(random -1)].CompareTag("Squirrel"))
                {
                    improvedTechnique.transform.SetParent(effectSlots[index].transform, false);
                }else if(allEventCards[(random -1)].CompareTag("Snake"))
                {
                    venom.transform.SetParent(effectSlots[index].transform, false);
                }else if(allEventCards[(random -1)].CompareTag("Lake"))
                {
                    fungus.transform.SetParent(effectSlots[index].transform, false);
                }else if(allEventCards[(random -1)].CompareTag("Treehouse")){
                    axe.transform.SetParent(effectSlots[index].transform, false);
                    matches.transform.SetParent(effectSlots[index].transform, false);
                }

                allEventCards.RemoveAt(random - 1);
                index++;
            }

            if(InventoryMgr3D.inst.levelOneComplete){
                clearSticks();
            }
        }
    }

    public void hideOtherItem()
    {
        string currTag = currCard.transform.parent.gameObject.tag;
        string oppositeTag = currTag;
        if(System.String.Equals(currTag, "L0"))
            oppositeTag = "R0";
        else if(System.String.Equals(currTag, "R0"))
            oppositeTag = "L0";

        if(System.String.Equals(currTag, "L1"))
            oppositeTag = "R1";
        else if(System.String.Equals(currTag, "R1"))
            oppositeTag = "L1";

        foreach(GameObject itemSlot in itemSlots){
            if(itemSlot.CompareTag(oppositeTag))
                itemSlot.SetActive(false);
        }
    }

    public void hideOtherEvent()
    {
        string currTag = currCard.transform.parent.gameObject.tag;
        string oppositeTag = currTag;
        if(System.String.Equals(currTag, "L0"))
            oppositeTag = "R0";
        else if(System.String.Equals(currTag, "R0"))
            oppositeTag = "L0";

        if(System.String.Equals(currTag, "L1"))
            oppositeTag = "R1";
        else if(System.String.Equals(currTag, "R1"))
            oppositeTag = "L1";

        foreach(GameObject eventSlot in eventSlots){
            if(eventSlot.CompareTag(oppositeTag))
                eventSlot.SetActive(false);
        }
    }

    public void clearSticks(){
        tastySnack.SetActive(false);
        tastySnack1.SetActive(false);
        campfire0.SetActive(false);
        campfire1.SetActive(false);
        stick0.SetActive(false);
        stick1.SetActive(false);
    }
}
