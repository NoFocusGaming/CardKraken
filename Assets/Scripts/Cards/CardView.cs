using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardView : MonoBehaviour
{
    private InventoryMgr2D inventoryMgr;

    // Start is called before the first frame update
    void Start()
    {
        inventoryMgr = InventoryMgr2D.inst;
    }

    public GameObject selectedCard;
    public bool mouseSelect;

    private Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(inventoryMgr.companionCard){
                GraphicRaycaster graphicsRaycaster = this.GetComponent<GraphicRaycaster>();

                PointerEventData ped = new PointerEventData(null);
                ped.position = Input.mousePosition;

                List<RaycastResult> results = new List<RaycastResult>();

                graphicsRaycaster.Raycast(ped, results);

                foreach (RaycastResult result in results)
                {
                    if(result.gameObject.CompareTag("CardView")){
                        selectedCard = result.gameObject;
                        mouseSelect = true;
                        offset = selectedCard.transform.position - Input.mousePosition;
                    }
                }
            }
        }

        if(mouseSelect)
        {
            selectedCard.transform.position = Input.mousePosition + offset;
        }

        if(mouseSelect && Input.GetMouseButtonUp(0))
        {
            selectedCard = null;
            mouseSelect = false;
        }
    }

    void FixedUpdate(){
        if(mouseSelect && Utils.cardsOverlap(inventoryMgr.cardView.GetComponent<RectTransform>(), CompanionMgr.inst.companion.GetComponent<RectTransform>()))
            inventoryMgr.setCompanionSprite();
    }
}
