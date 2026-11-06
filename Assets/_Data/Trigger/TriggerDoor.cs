using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : BaseTrigger
{
    [SerializeField] protected Transform door;
    [SerializeField] protected UIDoorClick uiDoorButton;

    [SerializeField] protected float moveDistance = 3f;
    [SerializeField] protected float moveSpeed = 2f;

    [SerializeField] protected bool isOpen;

    protected Vector3 closedPosition;
    protected Vector3 openPosition;

    protected Coroutine moveCoroutine;

    private void Start()
    {
        this.closedPosition = this.door.localPosition;

        this.openPosition = this.closedPosition
                         + Vector3.down * this.moveDistance;

        this.uiDoorButton.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.uiDoorButton.ShowButton(this);
            Debug.Log("Show Door Button");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.uiDoorButton.HideButton(this);
            Debug.Log("Hide Door Button");
        }
    }

    public void InteractDoor()
    {
        this.isOpen = !this.isOpen;
        this.playerCtrl.PlayerInteract();

        Vector3 targetPosition = this.isOpen ? this.openPosition : this.closedPosition;

        if (this.moveCoroutine != null) StopCoroutine(this.moveCoroutine);

        this.moveCoroutine = StartCoroutine(MoveDoor(targetPosition));
    }

    protected IEnumerator MoveDoor(Vector3 targetPosition)
    {
        while (Vector3.Distance(
            this.door.localPosition, targetPosition) > 0.01f)
        {
            this.door.localPosition = Vector3.MoveTowards(
                this.door.localPosition,
                targetPosition,
                this.moveSpeed * Time.deltaTime
            );

            yield return null;
        }

        this.door.localPosition = targetPosition;
        this.moveCoroutine = null;
    }
}
