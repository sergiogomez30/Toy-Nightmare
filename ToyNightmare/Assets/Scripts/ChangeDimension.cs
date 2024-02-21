using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeDimension : MonoBehaviour
{
    public Camera ortographicCam;
    public Camera perspectiveCam;

    public CinemachineVirtualCamera twoDVirtualFakeCam;
    public CinemachineVirtualCamera threeDVirtualCam;

    public Camera startCam;
    private Camera currentCam;

    playerMovement scriptMovement;
    [HideInInspector] public bool changingDimension;

    private void Start()
    {
        currentCam = startCam;
        currentCam.depth = 1;
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
            if(currentCam == ortographicCam)
            {
                SwitchCamera(perspectiveCam);
            }
            else
            {
                SwitchCamera(ortographicCam);
            }
        }
    }

    public void SwitchCamera(Camera newCam)
    {
        currentCam = newCam;

        if (currentCam == ortographicCam)
        {
            threeDVirtualCam.Priority = 10;
            twoDVirtualFakeCam.Priority = 20;
            

            scriptMovement.dimension = 2;
        }
        else
        {
            ortographicCam.depth = 0;
            perspectiveCam.depth = 1;
            twoDVirtualFakeCam.Priority = 10;
            threeDVirtualCam.Priority = 20;

            scriptMovement.dimension = 3;
        }

        changingDimension = true;
        StartCoroutine(tiltPlayer());     
    }

    public IEnumerator tiltPlayer() //asegura que el personaje quede bien rotado después de un cambio de dimension
    {
        yield return new WaitForSeconds(1f);
        changingDimension = false;

        if (currentCam == ortographicCam)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            ortographicCam.depth = 1;
            perspectiveCam.depth = 0;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
        }

    }

    public void rotatePlayer()
    {
        transform.eulerAngles = new Vector3(0, perspectiveCam.transform.eulerAngles.y, 0);

        /*if (currentCam == twoDVirtualFakeCam)
        {
            transform.Rotate(0, -90 * Time.deltaTime, 0);
        }
        else
        {
            transform.Rotate(0, 90 * Time.deltaTime, 0);
        }*/
    }
}
