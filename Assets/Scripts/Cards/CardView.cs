using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardView : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject selectedCard;
    public bool mouseSelect;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("input mouse down button");

            GraphicRaycaster graphicsRaycaster = this.GetComponent<GraphicRaycaster>();

            PointerEventData ped = new PointerEventData(null);
            ped.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            graphicsRaycaster.Raycast(ped, results);

            foreach (RaycastResult result in results)
            {
                Debug.Log("hit objects on screen???");

                if(result.gameObject.CompareTag("CardView")){
                    Debug.Log("cardview tag");
                    selectedCard = result.gameObject;
                    mouseSelect = true;
                }
            }
        }

        if(mouseSelect && Input.GetMouseButtonUp(0))
        {
            selectedCard = null;
            mouseSelect = false;
        }

        
    }
}
