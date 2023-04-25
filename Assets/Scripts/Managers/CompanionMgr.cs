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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCompanion(Sprite currSprite){
        companion.GetComponent<UnityEngine.UI.Image>().sprite = currSprite;
    }
}
