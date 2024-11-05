using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public Transform handle;
    public Vector3 axis;
    public float speed;

    void Update()
    {
        Quaternion offset = Quaternion.Euler(axis * speed * Time.deltaTime);
        handle.localRotation *= offset;
    }
}
