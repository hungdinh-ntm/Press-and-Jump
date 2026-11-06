using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] protected MachineCtrl machine;

    protected virtual void Start()
    {
        this.machine = transform.parent.GetComponent<MachineCtrl>();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        this.machine.Action.Act();
    }
}
