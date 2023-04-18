using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// CameraMgr controls movement of camera in 3Dworld
public class CameraMgr : MonoBehaviour
{
    public static CameraMgr inst;
    
    private void Awake(){
        inst = this;
    }

    public GameObject cameraObj;
    public GameObject instructions;
    public GameObject currCard;

    public float cameraMoveSpeed = 2;
    public float cameraTurnRate = 100;

    public Vector3 currentYawEulerAngles = Vector3.zero;
    public Vector3 targetYawEulerAngles = Vector3.zero;
    private bool turning = false;
    private bool pressF = false;

    // Update is called once per frame
    void Update()
    {
        //rotating 90 degrees at key press
        if(!turning){
            if(Input.GetKeyUp(KeyCode.A))
                StartCoroutine(turn(Vector3.down));
            if(Input.GetKeyUp(KeyCode.D))
                StartCoroutine(turn(Vector3.up));
        }

        //very basic camera movement forwards
        if(Input.GetKeyUp(KeyCode.W))
            cameraObj.transform.Translate(Vector3.forward * cameraMoveSpeed);

        if(pressF && Input.GetKeyDown(KeyCode.F)){
            currCard.SetActive(false);
            SceneManager.LoadScene("GameBoard", LoadSceneMode.Additive);
        }

    }

    void FixedUpdate()
    {
        RaycastHit hit;

        //detection of card infront of objects
        if (Physics.Raycast (cameraObj.transform.position, cameraObj.transform.TransformDirection(Vector3.forward), out hit, 4))
        {
            Debug.Log("There is something in front of the object!");
            pressF = true;            
            currCard = hit.collider.gameObject;
        }else{
            pressF = false;
        }

        instructions.SetActive(pressF);
    }

    //coroutine to turn the camera 90 degrees at speed proportional to cameraTurnRate
    //to turn right use: Vector3.up; to turn left use: Vector3.down as 'direction'
    IEnumerator turn(Vector3 direction)
    {
        turning = true;
        currentYawEulerAngles = cameraObj.transform.localEulerAngles;
        targetYawEulerAngles = currentYawEulerAngles + direction * 90;
        targetYawEulerAngles.y = Utils.FixAngle(targetYawEulerAngles.y);

        while(!Utils.ApproximatelyEqual(currentYawEulerAngles.y, targetYawEulerAngles.y)){
            currentYawEulerAngles += direction * Time.deltaTime * cameraTurnRate;
            cameraObj.transform.localEulerAngles = currentYawEulerAngles;
            yield return null;
        }

        currentYawEulerAngles.y = Utils.FixAngle(currentYawEulerAngles.y);
        currentYawEulerAngles.y = Utils.Degrees360(currentYawEulerAngles.y);
        cameraObj.transform.localEulerAngles = currentYawEulerAngles;

        turning = false;
    }
}
