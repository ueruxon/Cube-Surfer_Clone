using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button _restartButton;

    private CanvasGroup _canvasGroup;

    private void Start() {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
        _restartButton.enabled = false;

        GameManager.Instance.GameOvered += OnGameOvered;
        _restartButton.onClick.AddListener(GameManager.Instance.RestartGame);
    }

    private void OnDisable() {
        GameManager.Instance.GameOvered -= OnGameOvered;
        _restartButton.onClick.RemoveListener(GameManager.Instance.RestartGame);
    }

    private void OnGameOvered() {
        _canvasGroup.alpha = 1;
        _restartButton.enabled = true;
    }
}
