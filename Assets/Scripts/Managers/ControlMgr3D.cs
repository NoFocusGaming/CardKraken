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
    public GameObject instructions;

    public bool pressF = false;

    // Start is called before the first frame update
    void Start()
    {
        cameraMgr = CameraMgr.inst;
        cardMgr3D = CardMgr3D.inst;
    }

    // Update is called once per frame
    void Update()
    {
        //loading gameboard scene when card is in front of player + they press 'f' key
        if(pressF && Input.GetKeyDown(KeyCode.F)){
            cardMgr3D.currCard.SetActive(false);
            SceneManager.LoadScene("GameBoard", LoadSceneMode.Additive);
        }
    }

    void FixedUpdate()
    {
        RaycastHit hit;

        //detection of card infront of objects
        if (Physics.Raycast (cameraMgr.cameraObj.transform.position, cameraMgr.cameraObj.transform.TransformDirection(Vector3.forward), out hit, 8))
        {
            Debug.Log("There is something in front of the object!");
            pressF = true;            
            cardMgr3D.currCard = hit.collider.gameObject;
        }else{
            pressF = false;
        }

        instructions.SetActive(pressF);
    }
}
