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

    playerMovement scriptMovement;
    public bool changingDimension;

    private void Start()
    {
        currentCam = startCam;
        currentCam.Priority = 20;
        scriptMovement = this.GetComponent<playerMovement>();
        changingDimension = false;
    }

    void Update()
    {
        changeDimension();

        if (changingDimension)
        {
            rotatePlayer();
        }
    }

    public void changeDimension()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !changingDimension)
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
            scriptMovement.dimension = 2;
        }
        else
        {
            twoDCam.Priority = 10;
            scriptMovement.dimension = 3;
        }

        changingDimension = true;
        StartCoroutine(tiltPlayer());     
    }

    public IEnumerator tiltPlayer()
    {
        yield return new WaitForSeconds(1f);
        changingDimension = false;

        if(currentCam == twoDCam)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
        }

    }

    public void rotatePlayer()
    {
        if(currentCam == twoDCam)
        {
            transform.Rotate(0, -90 * Time.deltaTime, 0);
        }
        else
        {
            transform.Rotate(0, 90 * Time.deltaTime, 0);
        }
    }
}
