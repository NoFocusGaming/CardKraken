using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CameraMgr controls movement of camera in 3Dworld
public class CameraMgr : MonoBehaviour
{
    public static CameraMgr inst;

    private void Awake(){
        inst = this;
    }

    public GameObject cameraObj;
    public float cameraMoveSpeed = 2;
    public float cameraTurnRate = 100;

    public Vector3 currentYawEulerAngles = Vector3.zero;
    public Vector3 targetYawEulerAngles = Vector3.zero;
    private bool turning = false;

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            //rotating 90 degrees at key press
            if (!turning)
            {
                if (Input.GetKeyUp(KeyCode.A))
                    StartCoroutine(turn(Vector3.down));
                if (Input.GetKeyUp(KeyCode.D))
                    StartCoroutine(turn(Vector3.up));
            }

            //very basic camera movement forwards
            if (Input.GetKeyUp(KeyCode.W))
                cameraObj.transform.Translate(Vector3.forward * cameraMoveSpeed);
        }
    }

    /*
    //commented out the old one!
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
    */
    //new code to fix rotation bug
    IEnumerator turn(Vector3 direction)
    {
        turning = true;
        currentYawEulerAngles = cameraObj.transform.eulerAngles;
        targetYawEulerAngles = currentYawEulerAngles + direction * 90;
        targetYawEulerAngles.y = Utils.FixAngle(targetYawEulerAngles.y);

        float elapsed = 0;
        float duration = Mathf.Abs(90 / cameraTurnRate);
        while (elapsed < duration)
        {
            float rotationAmount = Time.deltaTime * cameraTurnRate;
            cameraObj.transform.Rotate(direction * rotationAmount, Space.Self);
            elapsed += Time.deltaTime;
            yield return null;
        }

        currentYawEulerAngles = cameraObj.transform.eulerAngles;
        currentYawEulerAngles.y = Utils.FixAngle(currentYawEulerAngles.y);
        currentYawEulerAngles.y = Utils.Degrees360(currentYawEulerAngles.y);
        cameraObj.transform.eulerAngles = currentYawEulerAngles;

        turning = false;
    }
}
