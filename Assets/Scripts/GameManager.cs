using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState {
    Menu,
    Started,
    Playing
}

public class GameManager : MonoBehaviour {
    [SerializeField] private Movement playerMovement;
    
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera lemurCamera;

    private GameState _gameState;
    private void Awake(){
        _gameState = GameState.Started;
        // SceneManager.LoadSceneAsync("Kinga");
        SceneManager.LoadScene("Kinga", LoadSceneMode.Additive);
        SceneManager.LoadScene("Lesio", LoadSceneMode.Additive);
        SceneManager.LoadScene("Maciek", LoadSceneMode.Additive);
        SceneManager.LoadScene("Kuba", LoadSceneMode.Additive);
    }

    public void Start(){
        playerMovement = GameObject.Find("Giraffe").GetComponent<Movement>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        lemurCamera = GameObject.Find("LemurCamera").GetComponent<Camera>();
        Camera.SetupCurrent(lemurCamera);
        playerMovement._canPlayerMove = false;
        StartCoroutine(WaitAndEnableGame());
    }

    IEnumerator WaitAndEnableGame(){
        yield return new WaitForSecondsRealtime(3f);
        EnableGame();
    }

    private void EnableGame(){
        _gameState = GameState.Playing;
        playerMovement._canPlayerMove = true;
        Camera.SetupCurrent(mainCamera);
    }
}
