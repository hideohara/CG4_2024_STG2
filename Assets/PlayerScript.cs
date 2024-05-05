using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveSpeed = 2.0f;
        float stageMax = 4.0f;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < stageMax)
            {
                rb.velocity = new Vector3(moveSpeed, 0, 0);
            }
            animator.SetBool("Move", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > -stageMax)
            {
                rb.velocity = new Vector3(-moveSpeed, 0, 0);
            }
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
            rb.velocity = new Vector3(0, 0, 0);
        }

    }
}
