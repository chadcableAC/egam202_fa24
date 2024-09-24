using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoomSwitcher : MonoBehaviour
{
    public Camera myCamera;

    public float spherecastRadius = 1f;

    public RoomCameraSwitcher overheadRoom;


    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
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
        else if (Input.GetMouseButtonDown(1))
        {
            overheadRoom.MakePriority();
        }
    }
}
