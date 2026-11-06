using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    [SerializeField] protected CheckPointManager checkPointManager;
    [SerializeField] protected UIDead uiDead;

    [SerializeField] protected bool gameOver = false;
    public bool _GameOver => gameOver;

    private void Awake()
    {
        GameManager.instance = this;
    }

    private void Start()
    {
        this.HideUIDead();
    }

    public virtual void GameOver()
    {
        this.gameOver = true;
        Time.timeScale = 0f;
    }

    public virtual void Replay()
    {
        Time.timeScale = 1f;
        this.checkPointManager.currentCheckPoint = null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public virtual void PlayerDie()
    {
        this.uiDead.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public virtual void HideUIDead()
    {
        this.uiDead.gameObject.SetActive(false);
    }
}
