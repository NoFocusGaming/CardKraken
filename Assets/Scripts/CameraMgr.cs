using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMgr : MonoBehaviour
{
    public static CameraMgr inst;
    private void Awake(){
        inst = this;
    }
    

    public GameObject cameraObj;

    public float cameraMoveSpeed = 100;
    public float cameraTurnRate = 60;

    public Vector3 currentYawEulerAngles = Vector3.zero;
    public Vector3 targetYawEulerAngles = Vector3.zero;
    private bool turning = false;

    // Update is called once per frame
    void Update()
    {
        if(!turning){
            if(Input.GetKeyUp(KeyCode.A))
                StartCoroutine(turnLeft());
            if(Input.GetKeyUp(KeyCode.D))
                StartCoroutine(turnRight());
        }
    }

    IEnumerator turnRight()
    {
        turning = true;
        currentYawEulerAngles = cameraObj.transform.localEulerAngles;
        targetYawEulerAngles = currentYawEulerAngles + Vector3.up * 90;
        targetYawEulerAngles.y = Utils.FixAngle(targetYawEulerAngles.y);

        while(!Utils.ApproximatelyEqual(currentYawEulerAngles.y, targetYawEulerAngles.y)){
            currentYawEulerAngles += Vector3.up * Time.deltaTime * cameraTurnRate;
            cameraObj.transform.localEulerAngles = currentYawEulerAngles;
            yield return null;
        }

        currentYawEulerAngles.y = Utils.FixAngle(currentYawEulerAngles.y);
        currentYawEulerAngles.y = Utils.Degrees360(currentYawEulerAngles.y);

        turning = false;
    }

    IEnumerator turnLeft()
    {
        turning = true;
        currentYawEulerAngles = cameraObj.transform.localEulerAngles;
        targetYawEulerAngles = currentYawEulerAngles + Vector3.down * 90;
        targetYawEulerAngles.y = Utils.FixAngle(targetYawEulerAngles.y);

        while(!Utils.ApproximatelyEqual(currentYawEulerAngles.y, targetYawEulerAngles.y)){
            currentYawEulerAngles += Vector3.down * Time.deltaTime * cameraTurnRate;
            cameraObj.transform.localEulerAngles = currentYawEulerAngles;
            yield return null;
        }
        
        currentYawEulerAngles.y = Utils.FixAngle(currentYawEulerAngles.y);
        currentYawEulerAngles.y = Utils.Degrees360(currentYawEulerAngles.y);
        turning = false;
    }
    
}
