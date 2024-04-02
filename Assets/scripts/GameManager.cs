using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverUI;

    void Start()
    {
        gameOverUI.SetActive(false);
        GameEvents.PlayerDied.AddListener(GameOver);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    void GameOver()
    {

        gameOverUI.SetActive(true);
    }

    void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
