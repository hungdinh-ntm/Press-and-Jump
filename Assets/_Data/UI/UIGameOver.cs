using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] protected Transform textGO;
    [SerializeField] protected Transform buttonGO;

    //private void Start()
    //{
    //    this.textGO = transform.Find("TextGO");
    //    this.buttonGO = transform.Find("ButtonGO");
    //}

    private void Update()
    {
        this.ShowUIGameOver();
    }

    protected virtual void ShowUIGameOver()
    {
        if (GameManager.Instance._GameOver)
        {
            this.textGO.gameObject.SetActive(true);
            this.buttonGO.gameObject.SetActive(true);
            return;
        }

        this.textGO.gameObject.SetActive(false);
        this.buttonGO.gameObject.SetActive(false);
    }

    public virtual void ResetTheGame()
    {
        GameManager.Instance.Replay();
    }
}
