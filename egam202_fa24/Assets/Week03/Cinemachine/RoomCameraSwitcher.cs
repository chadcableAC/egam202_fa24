using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RoomCameraSwitcher : MonoBehaviour
{
    // Camera value
    public CinemachineVirtualCamera roomCamera;

    public void MakePriority()
    {
        // Find ALL of teh virtual cameras in the scene and set them to 0
        CinemachineVirtualCamera[] allCameras = FindObjectsOfType<CinemachineVirtualCamera>();
        foreach (CinemachineVirtualCamera cam in allCameras)
        {
            cam.Priority = 0;
        }

        // Then make our camera the highest priority
        roomCamera.Priority = 100;
    }
}