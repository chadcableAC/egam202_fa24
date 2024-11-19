using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControllerScript : MonoBehaviour
{
    public Animator animator;

    public float jumpDuration;
    float jumpTimer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isSpacebar = Input.GetKey(KeyCode.Space);

        if (isSpacebar)
        {
            jumpTimer += Time.deltaTime;
        }
        else
        {
            int jumpStrength = 0;
            if (jumpTimer > jumpDuration)
            {
                jumpStrength = 2;
            }
            else if (jumpTimer > jumpDuration * 0.5f)
            {
                jumpStrength = 1;
            }
            animator.SetInteger("JumpStrength", jumpStrength);

            jumpTimer = 0;
        }

        animator.SetBool("IsSpacebar", isSpacebar);
    }
}
