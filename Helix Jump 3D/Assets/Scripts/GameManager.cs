using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;
    public bool levelCompleted = false;

    public GameObject GameOverPanel;
    public GameObject LevelCompletedPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            GameOverPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        if (levelCompleted)
        {
            LevelCompletedPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Level");
    }

    public void ContinueButtton()
    {
        SceneManager.LoadScene("Level");
    }
}
