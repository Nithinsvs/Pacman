using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private static UIManager instance;
    public static UIManager Instance { get { return instance; } }

    [SerializeField] public GameObject playButton;
    [SerializeField] private GameObject restartButton;

    public Action gameStarted, gameOver;


    private void Awake()
    {
        instance = this; 
    }


    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement.gameOver += ShowGameover;
        playButton.SetActive(true);
    }

    private void OnDisable()
    {
        PlayerMovement.gameOver -= ShowGameover;
    }

    public void PlayGame()
    {
        playButton.SetActive(false);
        gameStarted.Invoke();
    }

    //Register game over and notify all scripts
    public void ShowGameover()
    {
        restartButton.SetActive(true);
        gameOver.Invoke();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("-----clicked on ui-----");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("-----clicked on ui-----");
    }

}
