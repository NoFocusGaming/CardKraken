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
    public float cameraTurnRate = 100;

    public Vector3 currentYawEulerAngles = Vector3.zero;
    public Vector3 targetYawEulerAngles = Vector3.zero;
    private bool turning = false;

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
    }

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
