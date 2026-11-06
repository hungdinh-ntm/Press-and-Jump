using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCheckPointGO : ActionCheckPoint
{
    public override void Act()
    {
        base.Act();
        GameManager.Instance.GameOver();
    }
}
