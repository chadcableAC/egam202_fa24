using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureElement : MonoBehaviour
{
    public List<Transform> pikminReferenceTransforms;
    public int pikminCounter = 0;


    private void OnTriggerEnter(Collider other)
    {
        NewPikminCharacter pikmin = other.GetComponent<NewPikminCharacter>();
        if (pikmin != null)
        {
            if (pikminCounter < pikminReferenceTransforms.Count)
            {
                Transform newParent = pikminReferenceTransforms[pikminCounter];
                other.transform.SetParent(newParent, false);
                other.transform.localPosition = Vector3.zero;

                pikminCounter++;
            }
        }
    }
}
