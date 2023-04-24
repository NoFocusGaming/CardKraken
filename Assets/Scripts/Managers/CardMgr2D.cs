using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
CardMgr2D is a child of CardMgr class
Designed to manage all cards in 2D (GameBoard) scene 
*/
public class CardMgr2D : MonoBehaviour
{
    public static CardMgr2D inst;
    private void Awake(){
        inst = this;
    }


    public List<GameObject> allCardsObjects;
    public List<Card> allCards;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
