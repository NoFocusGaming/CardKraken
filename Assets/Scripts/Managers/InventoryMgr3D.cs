using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMgr3D : MonoBehaviour
{
    public static InventoryMgr3D inst;
    private void Awake(){
        inst = this;
    }

    public List<Card> currInventory;

    public int maxCards;

    public List<Sprite> currInvSprites;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
