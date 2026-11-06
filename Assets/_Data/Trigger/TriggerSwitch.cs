using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSwitch : BaseTrigger
{
    [SerializeField] protected GameObject uiSwitchClick;
    [SerializeField] protected GameObject stairStep;
    [SerializeField] protected bool isActive;

    private void Start()
    {
        this.uiSwitchClick.SetActive(false);
        this.stairStep.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.uiSwitchClick.SetActive(true);
            Debug.Log("Enter Switch");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.uiSwitchClick.SetActive(false);
            Debug.Log("Out Switch");
        }
    }

    public void InteractSwitch()
    {
        this.isActive = !this.isActive;
        this.playerCtrl.PlayerInteract();

        if (this.isActive)
        {
            this.stairStep.SetActive(true);
        }
        else
        {
            this.stairStep.SetActive(false);
        }
    }
}
