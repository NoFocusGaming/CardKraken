using System;
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
    public bool obstacle = false;

    // Update is called once per frame
    void Update()
    {
        if (!ControlMgr3D.inst.inventoryOpen && !PauseMenu.isPaused)
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
            if (!obstacle && Input.GetKeyUp(KeyCode.W))
                // i added "multiply by 5" so it goes farther instead of player having to press W button multiple times to get to each card
                // feel free to change or back to original one - jules
                cameraObj.transform.Translate(Vector3.forward * cameraMoveSpeed * 5);
        }
    }

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
