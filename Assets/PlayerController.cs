using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 10;
    private Rigidbody rb;
    private bool canJump = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Move(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(Vector3.back);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
        }

        if (Input.GetKey(KeyCode.Space) && canJump)
        {
            Jump();
        }
    }

    private void Move(Vector3 moveDirection)
    {
        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        canJump = false;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        StartCoroutine(JumpReset());
    }

    private IEnumerator JumpReset()
    {
        yield return new WaitForSeconds(2.0f);
        canJump = true;
    }
    
}
