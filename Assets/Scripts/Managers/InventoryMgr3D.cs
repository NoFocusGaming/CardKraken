using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMgr3D : MonoBehaviour
{
    public static InventoryMgr3D inst;
    private void Awake(){
        inst = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public List<string> currInvTags;

    public int maxCards;

    public List<Sprite> currInvSprites;

    public List<bool> currInvWeapon;

    public Sprite currCompanion;

    public int currLevel; //0 = tutorial, 1 = level 1, 2 = level 2, 3 = boss level, 4 = village
    public bool tutorialComplete = false, levelOneComplete = false, levelTwoComplete = false, bossComplete = false;

    public int krakenHealth = 10;

    // function to wipe inventory (called on event failure)
    public void wipeInventory(){
        currInvSprites.Clear();
        currInvTags.Clear();
        currInvWeapon.Clear();
    }

    // handling successful weapon use against kraken
    public void AttackKraken(int damage){
        Debug.Log("Attack Kraken with damage: " + damage);
        krakenHealth -= damage;
        if(krakenHealth < 0){
            Debug.Log("Player Wins!");
        }
    }
}
