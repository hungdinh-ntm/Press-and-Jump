using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    [SerializeField] protected LayerMask groundLayer;
    [SerializeField] protected BoxCollider box;

    [SerializeField] protected bool isGrounded;
    public bool IsGrounded => isGrounded;

    private void Update()
    {
        this.CheckGrounded();
    }

    public virtual void CheckGrounded()
    {
        Vector3 centerPos = box.transform.TransformPoint(box.center);
        Vector3 halfExtents = Vector3.Scale(box.size, transform.localScale) / 2f;

        Collider[] colliders = Physics.OverlapBox(centerPos, halfExtents, box.transform.rotation, groundLayer);
        this.isGrounded = colliders.Length > 0;

        //if (this.isGrounded)
        //    Debug.Log("cham dat");

        //else
        //    Debug.Log("khong cham dat");
    }
}
