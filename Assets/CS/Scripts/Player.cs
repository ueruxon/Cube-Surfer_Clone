using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _startCubesCount;
    [SerializeField] private CubePool _cubePool;

    private void Start() {
        _cubePool.CubesCountChanged += OnCubesCountChanged;

        for (int i = 0; i < _startCubesCount; i++) {
            _cubePool.AddCube();
        }
    }

    private void OnDisable() {
        _cubePool.CubesCountChanged -= OnCubesCountChanged;
    }

    private void OnCubesCountChanged(int count) {
        if (count <= 0) {
            GameManager.Instance.GameOver();
        }
    }
}
