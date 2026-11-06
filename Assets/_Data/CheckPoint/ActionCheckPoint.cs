using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCheckPoint : Action
{
    [SerializeField] protected MachineCtrl machine;

    protected virtual void Start()
    {
        this.machine = transform.parent.GetComponent<MachineCtrl>();
    }

    public override void Act()
    {
        this.SaveCheckPoint();
    }

    protected virtual void SaveCheckPoint()
    {
        CheckPointManager.Instance.SetCheckPoint(this.machine);
    }
}
