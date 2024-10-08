using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectGoal : MonoBehaviour
{
    public TextMeshPro textAmount;
    public int maxObjects = 5;

    public Vector3 cubeSize;

    void Update()
    {
        int count = 0;

        // See what objects are in this box
        RaycastHit[] hits = Physics.BoxCastAll(transform.position, cubeSize / 2f, Vector3.up, Quaternion.identity, cubeSize.y);
        foreach (RaycastHit hit in hits)
        {
            ObjectCharacter objChar = hit.transform.GetComponent<ObjectCharacter>();
            if (objChar != null)
            {
                count++;
            }
        }

        // These two lines are the same - just a difference in syntax
        //textAmount.text = string.Format("Objects {0} / {1}", count, maxObjects);
        textAmount.text = $"Objects {count} / {maxObjects}";
    }
}
