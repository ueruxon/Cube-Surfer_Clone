using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Default, Started, GameOver, LevelEnd };

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameState CurrentGameState;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        CurrentGameState = GameState.Default;
    }

    public void StartGame() {
        CurrentGameState = GameState.Started;
    }

    public void GameOver() {
        CurrentGameState = GameState.GameOver;
        print("GAME OVER");
    }
}
