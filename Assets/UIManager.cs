using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject restartButton;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement.gameOver += ShowGameover;
        playButton.SetActive(true);
    }

    public void PlayGame()
    {
        playButton.SetActive(false);
    }

    public void ShowGameover()
    {
        restartButton.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

}
