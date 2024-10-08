using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballFlipper : MonoBehaviour
{
    public KeyCode key;

    public HingeJoint joint;

    public float activeVelocity = 100;
    public float inactiveVelocity = -100;

    void Update()
    {
        bool isActivated = Input.GetKey(key);

        JointMotor motor = joint.motor;

        if (isActivated)
        {
            motor.targetVelocity = activeVelocity;
        }
        else
        {
            motor.targetVelocity = inactiveVelocity;
        }

        joint.motor = motor;
    }
}
