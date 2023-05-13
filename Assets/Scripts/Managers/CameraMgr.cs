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

    public bool busy;

    public GameObject cameraObj;
    float cameraMoveSpeed = 2.5f;
    float cameraTurnRate = 120;

    public Vector3 currentYawEulerAngles = Vector3.zero;
    public Vector3 targetYawEulerAngles = Vector3.zero;
    private bool turning = false;
    public bool obstacle = false;

    private void Start()
    {
        busy = false;
    }

    void Update()
    {
        if (!busy)
        {
            if (!ControlMgr3D.inst.inventoryOpen && !PauseMenu.isPaused)
            {
                if (!turning)
                {
                    //rotating 90 degrees at key press
                    if (Input.GetKeyUp(KeyCode.A))
                    {
                        StartCoroutine(turn(Vector3.down));
                        busy = true;
                    }
                    if (Input.GetKeyUp(KeyCode.D)) { 
                        StartCoroutine(turn(Vector3.up));
                        busy = true;
                    }
                }
                //very basic camera movement forwards
                if (!obstacle && Input.GetKeyUp(KeyCode.W))
                {
                    // feel free to adjust the cameraMoveSpeed variable above
                    cameraObj.transform.Translate(Vector3.forward * cameraMoveSpeed);

                    if (InventoryMgr3D.inst.newToVillage)
                    {
                        CompanionMgr.inst.removeDialogue();
                        InventoryMgr3D.inst.newToVillage = false;
                    }
                }
            }
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

        currentYawEulerAngles = targetYawEulerAngles;
        currentYawEulerAngles.y = Utils.FixAngle(currentYawEulerAngles.y);
        currentYawEulerAngles.y = Utils.Degrees360(currentYawEulerAngles.y);
        cameraObj.transform.eulerAngles = currentYawEulerAngles;

        turning = false;
        busy = false;
    }
}
