using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTrigger : MonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;

    void Awake()
    {
        this.LoadPlayerCtrl();
    }

    protected void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        Debug.Log("Load PlayerCtrl");
    }
}
