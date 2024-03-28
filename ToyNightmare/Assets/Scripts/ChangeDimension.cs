using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeDimension : MonoBehaviour
{
    public Camera ortographicCam;
    public Camera perspectiveCam;

    public CinemachineVirtualCamera twoDVirtualFakeCam;
    public CinemachineVirtualCamera twoDVirtualFakeCam_2;
    public CinemachineVirtualCamera threeDVirtualCam;

    public Camera startCam;
    private Camera currentCam;

    private playerMovement scriptMovement;
    [HideInInspector] public bool changingDimension;
    [HideInInspector] public bool canDash;

    private GameObject weaponSystem;
    private GameObject crosshair;

    private float changeDimensionTimer;

    private ResetAnimations scriptResetAnimations;

    private void Start()
    {
        currentCam = startCam;
        currentCam.depth = 1;
        scriptMovement = GetComponent<playerMovement>();
        changingDimension = false;
        canDash = true;

        weaponSystem = GameObject.Find("WeaponSystem");
        crosshair = GameObject.Find("Crosshair");

        scriptResetAnimations = GetComponent<ResetAnimations>();
    }

    void Update()
    {
        changeDimension();
        rotatePlayer();
    }

    public void changeDimension()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !changingDimension)
        {
            changingDimension = true;
            changeDimensionTimer = 0;
            canDash = false;

            if (currentCam == ortographicCam)
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
            twoDVirtualFakeCam_2.Priority = 20;

            weaponSystem.SetActive(true);
            crosshair.SetActive(true);

            scriptMovement.dimension = 2;
        }
        else
        {
            ortographicCam.depth = 0;
            perspectiveCam.depth = 1;
            twoDVirtualFakeCam.Priority = 10;
            threeDVirtualCam.Priority = 20;

            crosshair.SetActive(false);
            weaponSystem.SetActive(false);
            scriptResetAnimations.resetShootEffectSprite(); //devuelve la animación de disparo a su estado inicial por si acaso
            scriptResetAnimations.resetWeaponSprite();

            scriptMovement.dimension = 3;
        }  
    }

    public void tiltPlayerAndCameras() //asegura que el personaje y las cámaras queden bien posicionados después de un cambio de dimension
    {
        changingDimension = false;

        if (currentCam == ortographicCam)
        {
            ortographicCam.depth = 1;
            perspectiveCam.depth = 0;
            twoDVirtualFakeCam.Priority = 20;
            twoDVirtualFakeCam_2.Priority = 10;
            //transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            //transform.eulerAngles = new Vector3(0, 90, 0);
        }

    }

    public void rotatePlayer()
    {
        if (changingDimension)
        {
            transform.eulerAngles = new Vector3(0, perspectiveCam.transform.eulerAngles.y, 0);

            changeDimensionTimer += Time.deltaTime;
            if (currentCam == ortographicCam)
            {
                if (changeDimensionTimer >= 1)
                {
                    tiltPlayerAndCameras();
                }
            }
            else
            {
                if (changeDimensionTimer >= 0.44f)
                {
                    tiltPlayerAndCameras();
                }
            }

            if (changeDimensionTimer >= 0.2f)
            {
                canDash = true; //permite dashear poco después de que empiece la animación de cambio de dimensión
            }


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
}
