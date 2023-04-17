using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionMgr : MonoBehaviour
{
    public static CompanionMgr inst;
    private void Awake(){
        inst = this;
    }

    public Card companion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
