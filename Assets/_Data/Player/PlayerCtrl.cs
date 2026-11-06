using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] protected Rigidbody rb;
    public Rigidbody Rb => rb;

    [SerializeField] protected PlayerMove playerMove;
    public PlayerMove PlayerMove => playerMove;

    public virtual void PlayerInteract()
    {
        this.playerMove.Animator.SetTrigger("Interact");
    }

    public virtual void Die()
    {
        Debug.Log("Player Die");
    }
}
