using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected float jumpForce = 5f;

    [SerializeField] protected bool isMoving;
    [SerializeField] protected Animator animator;
    public Animator Animator => animator;

    [SerializeField] protected CheckGround checkGround;

    private void Update()
    {
        this.UpdateAnimation();
    }

    private void FixedUpdate()
    {
        this.Moving();
        this.Jump();
    }

    protected virtual void UpdateAnimation()
    {
        this.animator.SetBool("isMoving", this.CheckMoving());
        this.animator.SetBool("isGrounded", this.checkGround.IsGrounded);
    }

    protected virtual void Moving()
    {
        Vector2 inputPos = InputManager.Instance.InputPos;
        Vector3 movement = new Vector3(inputPos.x, 0, inputPos.y);

        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0f;
        movement = Quaternion.LookRotation(cameraForward) * movement;

        rb.MovePosition(rb.position + movement * this.moveSpeed * Time.fixedDeltaTime);

        this.HanldeRotaion(movement);
    }

    protected virtual void Jump()
    {
        if (!InputManager.Instance.CanJump) return;
        if (!this.checkGround.IsGrounded) return;

        rb.AddForce(Vector3.up * this.jumpForce, ForceMode.Impulse);

        InputManager.Instance.ResetJump();

    }

    protected virtual bool CheckMoving()
    {
        Vector2 inputPos = InputManager.Instance.InputPos;
        if (inputPos.magnitude > 0.1f) this.isMoving = true;
        else this.isMoving = false;

        return this.isMoving;
    }

    protected virtual void HanldeRotaion(Vector3 playerMovement)
    {
        Vector3 lookDirection = playerMovement;
        lookDirection.y = 0f;

        if (lookDirection != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(lookDirection);
            this.animator.transform.rotation = rotation;
        }
    }
}
