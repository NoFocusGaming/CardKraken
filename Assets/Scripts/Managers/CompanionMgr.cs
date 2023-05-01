using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//CompanionMgr is a class to control the visuals and AI of companion
public class CompanionMgr : MonoBehaviour
{
    public static CompanionMgr inst;
    private void Awake(){
        inst = this;
    }

    public GameObject companion;
    public List<GameObject> dialogue;

    public InventoryMgr3D inventoryMgr;

    // Start is called before the first frame update
    void Start()
    {
        inventoryMgr = InventoryMgr3D.inst;

        if(inventoryMgr.currLevel != 0)
            setCompanion(inventoryMgr.currCompanion);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void setCompanion(Sprite currSprite){
        companion.GetComponent<UnityEngine.UI.Image>().sprite = currSprite;
        inventoryMgr.currCompanion = currSprite;
    }

    public void setDialogue(int index){
        dialogue[index].SetActive(true);
    }

    public void removeDialogue(){
        foreach(GameObject option in dialogue)
            option.SetActive(false);
    }
}
