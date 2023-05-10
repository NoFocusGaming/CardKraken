using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMgr : MonoBehaviour
{
    public static CharacterMgr inst;
    private void Awake(){
        inst = this;
    }

    public List<GameObject> currDialogueSet;
    public List<GameObject> grannyDialogue;
    public List<GameObject> foolDialogue;
    public List<GameObject> lover1Dialogue;
    public List<GameObject> lover2Dialogue;

    private InventoryMgr2D inventoryMgr;
    public int currDialogueIndex = 0;
    public bool dialogueDone = true;

    void Start()
    {
        inventoryMgr = InventoryMgr2D.inst;

        if(inventoryMgr.granny)
            currDialogueSet = grannyDialogue;
        else if(inventoryMgr.fool)
            currDialogueSet = foolDialogue;
        else if(inventoryMgr.lover1)
            currDialogueSet = lover1Dialogue;
        else if(inventoryMgr.lover2)
            currDialogueSet = lover2Dialogue;

        if(inventoryMgr.characterCard && currDialogueSet.Count > 0)
            currDialogueSet[currDialogueIndex].SetActive(true);
    }

    void Update()
    {
        if(currDialogueIndex == currDialogueSet.Count - 1)
            dialogueDone = true;
        else
            dialogueDone = false;

        if(inventoryMgr.characterCard){
            if(!dialogueDone && Input.GetKeyDown(KeyCode.F)){
                currDialogueSet[currDialogueIndex++].SetActive(false);
                currDialogueSet[currDialogueIndex].SetActive(true);
            }
        }
    }

    public void removeDialogue(){
        foreach(GameObject dialogue in currDialogueSet)
            dialogue.SetActive(false);

        InventoryMgr2D.inst.characterCard = false;
        InventoryMgr2D.inst.granny = false;
        InventoryMgr2D.inst.fool = false;
        InventoryMgr2D.inst.lover1 = false;
        InventoryMgr2D.inst.lover2 = false;
        InventoryMgr2D.inst.inventoryObject.SetActive(true);
    }
}
