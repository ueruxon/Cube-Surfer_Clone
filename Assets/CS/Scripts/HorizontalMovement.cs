using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    [SerializeField] private InputController _inputController;
    [SerializeField] private float _moveFromCenter = 2f;

    private void Update() {
        if (GameManager.Instance.CurrentGameState == GameState.Started) {
            MoveH(_inputController.HorizontalDelta);
        }
    }

    private void MoveH(float horizontalPosition) {
        Vector3 nextPosition = transform.localPosition;
        nextPosition.x = horizontalPosition * _moveFromCenter;

        transform.localPosition = nextPosition;
    }
}
