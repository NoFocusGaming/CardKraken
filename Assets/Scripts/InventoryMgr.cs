using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMgr : MonoBehaviour
{
    public static InventoryMgr inst;
    private void Awake(){
        inst = this;
    }

    public List<Card> currInventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
