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

    public List<Card> allCards;
    public GameObject currCard;  
    public GameObject tastySnack;
    public GameObject leaf, rock;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
