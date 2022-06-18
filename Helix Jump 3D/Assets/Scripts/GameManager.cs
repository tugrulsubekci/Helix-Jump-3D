using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;
    public bool levelCompleted = false;

    public GameObject GameOverPanel;
    public GameObject LevelCompletedPanel;

    public int currentLevel;
    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;

    private void Awake()
    {
        currentLevel = PlayerPrefs.GetInt("currentLevel", 1);
    }
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        // UI
        currentLevelText.text = $"{currentLevel}";
        nextLevelText.text = $"{currentLevel+1}";

        if (gameOver)
        {
            GameOverPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        if (levelCompleted)
        {
            LevelCompletedPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            PlayerPrefs.SetInt("currentLevel", currentLevel + 1);
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
