using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISwitchClick : MonoBehaviour
{
    [SerializeField] protected Button button;
    [SerializeField] protected TriggerSwitch triggerSwitch;

    private void Start()
    {
        this.button.onClick.AddListener(this.ClickSwitch);
    }

    protected void ClickSwitch()
    {
        if (this.triggerSwitch == null) return;
        this.triggerSwitch.InteractSwitch();
    }
}