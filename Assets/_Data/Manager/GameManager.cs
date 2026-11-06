using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    [SerializeField] protected CheckPointManager checkPointManager;
    [SerializeField] protected bool gameOver = false;
    public bool _GameOver => gameOver;

    private void Awake()
    {
        GameManager.instance = this;
    }

    public virtual void GameOver()
    {
        this.gameOver = true;
    }

    public virtual void Replay()
    {
        this.checkPointManager.currentCheckPoint = null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
