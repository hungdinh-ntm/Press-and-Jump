using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDoorClick : MonoBehaviour
{
    [SerializeField] protected Button button;
    [SerializeField] protected TriggerDoor currentDoor;

    private void Start()
    {
        //this.button.gameObject.SetActive(false);
        this.button.onClick.AddListener(this.ClickDoor);
    }

    public void ShowButton(TriggerDoor door)
    {
        this.currentDoor = door;
        this.button.gameObject.SetActive(true);
    }

    public void HideButton(TriggerDoor door)
    {
        if (this.currentDoor != door) return;

        this.currentDoor = null;
        this.button.gameObject.SetActive(false);
    }

    protected void ClickDoor()
    {
        if (this.currentDoor == null) return;
        this.currentDoor.InteractDoor();
    }
}
