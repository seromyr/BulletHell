using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using Constants;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager main;

    [SerializeField]
    private GameState gameState;

    [SerializeField]
    private bool stateUpdating;

    private string currentScene;

    private Canvas _mainMenu, _inGameMenu, gameOverMenu;

    [SerializeField]
    private int playerHealth;

    [SerializeField, Header("Money on game start")]
    private int money;
    public int CheckWallet { get { return money; } }

    private void Awake()
    {
        // Make the Game Manager a Singleton
        SingletonMaker();

        // Setup before loading the Main Menu
        InitialGameSetup();
    }

    void Start()
    {
        // Game loop starts
        stateUpdating = true;
    }

    private void SingletonMaker()
    {
        if (main == null)
        {
            DontDestroyOnLoad(gameObject);
            main = this;
            Debug.Log("Game Manager created");
        }
        else if (main != this)
        {
            Destroy(gameObject);
        }
    }

    private void InitialGameSetup()
    {
        // Construct player
        new PlayerEntity();
        Player.main.gameObject.SetActive(false);
        Player.main.Reset();

        // Set initial game state
        gameState = GameState.INIT;
    }

    private void OnLevelWasLoaded()
    {
        currentScene = SceneManager.GetActiveScene().name;
        switch (currentScene)
        {
            case SceneName.PRELOAD:
                // This will never happen
                break;

            case SceneName.MAINMENU:
                Debug.Log("Main Menu loaded");

                break;

            case SceneName.GAME:
                Debug.Log("Gameplay loaded");

                Player.main.transform.GetComponent<PlayerController>().LoadJoystick();

                GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().LookAt = (Player.main.transform);
                GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().Follow = (Player.main.transform);

                stateUpdating = true;
                break;
        }
    }

    private void Update()
    {
        if (stateUpdating)
        {
            GameStateMonitoring();
        }
    }

    private void GameStateMonitoring()
    {
        switch (gameState)
        {
            case GameState.INIT:
                // Game preload setup (works after Start())

                // Disable In Game Menu
                UI_InGameMenu_Mechanic.main.SetActiveCanvas(false);

                // Next step
                GoToMainMenu();

                //--------------------
                stateUpdating = false;
                break;

            case GameState.START:
                SceneManager.LoadScene(SceneName.MAINMENU);

                // Activate Main Menu UI
                UI_MainMenu_Mechanic.main.SetActiveCanvas(true);

                //--------------------
                stateUpdating = false;
                break;

            case GameState.NEW:
                SceneManager.LoadScene(SceneName.GAME);

                // Activate player
                Player.main.gameObject.SetActive(true);
                Player.main.Reset();

                // Deactivate Main Menu
                UI_MainMenu_Mechanic.main.SetActiveCanvas(false);

                // Activate In Game Menu
                UI_InGameMenu_Mechanic.main.SetActiveCanvas(true);

                // Next step
                ResumeGame();

                //--------------------
                stateUpdating = false;
                break;

            case GameState.RUNNING:
                Time.timeScale = 1;

                //--------------------
                stateUpdating = false;
                break;

            case GameState.PAUSE:
                //inGameMenu.
                Time.timeScale = 0;

                //--------------------
                stateUpdating = false;
                break;

            case GameState.LOSE:
                //--------------------
                stateUpdating = false;
                break;
        }
    }

    public void GoToMainMenu()
    {
        stateUpdating = true;
        gameState = GameState.START;
    }

    public void StartNewGame()
    {
        stateUpdating = true;
        gameState = GameState.NEW;
    }

    public void ResumeGame()
    {
        stateUpdating = true;
        gameState = GameState.RUNNING;
    }

    public void PauseGame()
    {
        stateUpdating = true;
        gameState = GameState.PAUSE;
    }
}