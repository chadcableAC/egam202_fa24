using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RoomCameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera roomCamera;



    public void MakePriority()
    {
        CinemachineVirtualCamera[] allCameras = FindObjectsOfType<CinemachineVirtualCamera>();
        foreach (CinemachineVirtualCamera cam in allCameras)
        {
            cam.Priority = 0;
        }

        roomCamera.Priority = 100;
    }
}