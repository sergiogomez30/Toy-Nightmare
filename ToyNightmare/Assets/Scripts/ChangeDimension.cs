using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeDimension : MonoBehaviour
{
    public CinemachineVirtualCamera twoDCam;
    public CinemachineVirtualCamera threeDCam;

    public CinemachineVirtualCamera startCam;
    CinemachineVirtualCamera currentCam;

    Vector3 rotationAngles;
    playerMovement scriptMovement;

    private void Start()
    {
        currentCam = startCam;
        currentCam.Priority = 20;
        scriptMovement = this.GetComponent<playerMovement>();
    }

    void Update()
    {
        changeDimension();
    }

    public void changeDimension()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(currentCam == twoDCam)
            {
                SwitchCamera(threeDCam);
            }
            else
            {
                SwitchCamera(twoDCam);
            }
        }
    }

    public void SwitchCamera(CinemachineVirtualCamera newCam)
    {
        currentCam = newCam;

        currentCam.Priority = 20;

        if (currentCam == twoDCam)
        {
            threeDCam.Priority = 10;

            rotationAngles = new Vector3(0, -90, 0);
            transform.Rotate(rotationAngles);
            scriptMovement.dimension = 2;
        }
        else
        {
            twoDCam.Priority = 10;

            rotationAngles = new Vector3(0, 90, 0);
            transform.Rotate(rotationAngles);
            scriptMovement.dimension = 3;
        }


    }
}
