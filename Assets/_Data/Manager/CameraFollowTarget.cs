using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected Vector3 offset = new Vector3(0, 1.7f, -4);
    [SerializeField] protected Quaternion rotation;

    [SerializeField] protected float x;
    [SerializeField] protected float y;
    [SerializeField] protected float xSpeed = 5f;
    [SerializeField] protected float ySpeed = 5f;

    [SerializeField] protected float xMinRotation = -360f;
    [SerializeField] protected float xMaxRotation = 360f;
    [SerializeField] protected float yMinRotation = 10f;
    [SerializeField] protected float yMaxRotation = 80f;

    private void Start()
    {
        this.GetAngle();
    }

    private void LateUpdate()
    {
        this.LockCamera();
        this.CameraMove();
        this.UpdateCameraAngle();
    }

    protected void GetAngle()
    {
        Vector3 angles = transform.eulerAngles;
        this.x = angles.y;
        this.y = angles.x;
    }

    protected void LockCamera()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Cursor.visible = !Cursor.visible;
            Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }

    protected void UpdateCameraAngle()
    {
        this.rotation = Quaternion.Euler(this.y, this.x, 0);

        Vector3 distanceVector = this.offset;
        Vector3 position = this.rotation * distanceVector + this.target.position;

        transform.position = position;
        transform.rotation = this.rotation;
    }

    protected void CameraMove()
    {
        if (!Input.GetMouseButton(0)) return;

        this.x += Input.GetAxis("Mouse X") * this.xSpeed;
        this.y -= Input.GetAxis("Mouse Y") * this.ySpeed;

        this.x = this.ClampAngle(this.x, this.xMinRotation, this.xMaxRotation);
        this.y = this.ClampAngle(this.y, this.yMinRotation, this.yMaxRotation);
    }

    protected float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }
}
