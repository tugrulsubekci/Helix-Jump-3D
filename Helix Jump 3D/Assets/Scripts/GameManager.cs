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
    public GameObject DragToPlay;

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
        if (currentLevel == 1)
        {
            DragToPlay.SetActive(true);
        }
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
        if(Input.GetMouseButtonDown(0))
        {
            DragToPlay.SetActive(false);
        }
    }

    public void RestartButton()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Invoke("LoadSceneLevel", 0.1f);
        
    }

    public void ContinueButtton()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Invoke("LoadSceneLevel", 0.1f);

    }

    public void LoadSceneLevel()
    {
        SceneManager.LoadScene("Level");
    }
}
