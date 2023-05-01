using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMgr3D : MonoBehaviour
{
    public static ControlMgr3D inst;  
    private void Awake(){
        inst = this;
    }

    public CameraMgr cameraMgr;
    public CardMgr3D cardMgr3D;
    public InventoryMgr3D inventoryMgr3D;
    public GameObject instructions;

    public bool pressF = false;
    public bool cardPresent = false;
    public bool inventoryOpen = false;

    public bool levelComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        cameraMgr = CameraMgr.inst;
        cardMgr3D = CardMgr3D.inst;
        inventoryMgr3D = InventoryMgr3D.inst;

        if(inventoryMgr3D.currLevel == 4){
            levelComplete = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //loading gameboard scene when card is in front of player + they press 'f' key
        if(!inventoryOpen && pressF && Input.GetKeyDown(KeyCode.F)){
            cardMgr3D.currCard.SetActive(false);
            inventoryOpen = true;
            SceneManager.LoadScene("GameBoard", LoadSceneMode.Additive);
        }

        if(!inventoryOpen && Input.GetKeyDown(KeyCode.I)){
            inventoryOpen = true;
            SceneManager.LoadScene("GameBoard", LoadSceneMode.Additive);
        }
    }

    void FixedUpdate()
    {
        if(!inventoryOpen){
            RaycastHit hit;

            //detection of card infront of objects
            if (Physics.Raycast (cameraMgr.cameraObj.transform.position, cameraMgr.cameraObj.transform.TransformDirection(Vector3.forward), out hit, 8))
            {
                if(!hit.collider.gameObject.CompareTag("Wall")){
                    pressF = true;            
                    cardPresent = true;
                    cardMgr3D.currCard = hit.collider.gameObject;
                    cameraMgr.obstacle = true;
                }
            }else{
                pressF = false;
                cameraMgr.obstacle = false;
            }

            instructions.SetActive(pressF);

            if(Physics.Raycast(cameraMgr.cameraObj.transform.position, cameraMgr.cameraObj.transform.TransformDirection(Vector3.forward), out hit, 2))
            {
                if(hit.collider.gameObject.CompareTag("Wall")){
                    cameraMgr.obstacle = true;
                }
            }

            if(levelComplete && Physics.Raycast(cameraMgr.cameraObj.transform.position, cameraMgr.cameraObj.transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
            {
                if(hit.collider.gameObject.CompareTag("LoadZoneVillage")){
                    inventoryMgr3D.currLevel = 4;
                    SceneManager.LoadScene("VillageCardWorld", LoadSceneMode.Single);
                }else if(hit.collider.gameObject.CompareTag("LoadZoneLvl1")){
                    inventoryMgr3D.currLevel = 1;
                    SceneManager.LoadScene("Level1CardWorld", LoadSceneMode.Single);
                }else if(hit.collider.gameObject.CompareTag("LoadZoneLvl2")){
                    inventoryMgr3D.currLevel = 2;
                    SceneManager.LoadScene("Level2CardWorld", LoadSceneMode.Single);
                }else if(hit.collider.gameObject.CompareTag("LoadZoneBoss")){
                    inventoryMgr3D.currLevel = 3;
                    SceneManager.LoadScene("BossCardWorld", LoadSceneMode.Single);
                }
            }
        }
    }
}
