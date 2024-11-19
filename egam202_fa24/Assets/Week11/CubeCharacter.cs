using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCharacter : MonoBehaviour
{
    public Animator animator;

    public Rigidbody rb;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputValue = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            inputValue += Vector3.left;
        }
        if (Input.GetKey(KeyCode.W))
        {
            inputValue += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputValue += Vector3.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputValue += Vector3.back;
        }

        rb.velocity = inputValue * speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("JumpTrigger");
        }

        float runVelocity = rb.velocity.magnitude;
        animator.SetFloat("RunVelocity", runVelocity);
    }
}
