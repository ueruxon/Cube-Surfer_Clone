using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public enum GameState { Default, Started, GameOver, LevelComplete };

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameState CurrentGameState { get; private set; }

    public event UnityAction GameOvered;


    [SerializeField] private PathFollower _pathFollower;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        CurrentGameState = GameState.Default;
        _pathFollower.LevelComplete += OnLevelComplete;
    }

    private void OnDisable() {
        _pathFollower.LevelComplete -= OnLevelComplete;
    }

    private void OnLevelComplete() {
        CurrentGameState = GameState.LevelComplete;
        // события?..
        GameOvered?.Invoke();
    }

    public void StartGame() {
        CurrentGameState = GameState.Started;
    }

    public void GameOver() {
        CurrentGameState = GameState.GameOver;
        print("GAME OVER");
        GameOvered?.Invoke();
    }

    public void RestartGame() {
        SceneManager.LoadScene(0);
    }
}
