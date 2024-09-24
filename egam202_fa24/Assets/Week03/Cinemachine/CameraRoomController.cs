using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoomSwitcher : MonoBehaviour
{
    // Camera values
    public Camera myCamera;

    public float spherecastRadius = 1f;

    public RoomCameraSwitcher overheadRoom;

    void Update()
    {
        // Run this logic on a left click
        if (Input.GetMouseButtonDown(0))
        {
            // Turn the mouse position into a world position
            Vector2 mousePosition = Input.mousePosition;
            Ray worldRay = myCamera.ScreenPointToRay(mousePosition);


            RaycastHit[] hits = Physics.SphereCastAll(worldRay, spherecastRadius);
            foreach (RaycastHit hit in hits)
            {
                RoomCameraSwitcher room = hit.transform.GetComponent<RoomCameraSwitcher>();
                if (room != null)
                {
                    room.MakePriority();
                }
            }
        }
        // Run this logic on a right click
        else if (Input.GetMouseButtonDown(1))
        {
            // Switch to the "overhead" room camera
            overheadRoom.MakePriority();
        }
    }
}
