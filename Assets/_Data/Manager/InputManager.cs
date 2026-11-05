using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance => instance;

    [SerializeField] protected Vector2 inputPos;
    public Vector2 InputPos => inputPos;

    [SerializeField] private bool canJump;
    public bool CanJump => canJump;

    private void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("Only 1 InputManager allow to exist");
        InputManager.instance = this;
    }

    private void Update()
    {
        this.GetInput();
    }

    void GetInput()
    {
        this.inputPos.x = Input.GetAxisRaw("Horizontal");
        this.inputPos.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space)) this.canJump = true;
    }

    public void ResetJump()
    {
        this.canJump = false;
    }
}
