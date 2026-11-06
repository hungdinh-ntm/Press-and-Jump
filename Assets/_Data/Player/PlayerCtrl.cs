using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] protected Rigidbody rb;
    public Rigidbody Rb => rb;

    [SerializeField] protected PlayerMove playerMove;
    public PlayerMove PlayerMove => playerMove;

    [SerializeField] protected bool isDead;
    public bool IsDead => isDead;

    public virtual void PlayerInteract()
    {
        this.playerMove.Animator.SetTrigger("Interact");
    }

    public virtual void Die()
    {
        Debug.Log("Player Die");
        this.playerMove.Animator.SetBool("IsDead", true);
        this.isDead = true;
        GameManager.Instance.PlayerDie();
    }

    public virtual void PlayerRevival()
    {
        Time.timeScale = 1f;
        this.isDead = false;
        this.playerMove.Animator.SetBool("IsDead", false);
        CheckPointManager.Instance.TeleOldPoint();
        GameManager.Instance.HideUIDead();
        //this.playerMove.Animator.SetTrigger("Reset");
    }
}
