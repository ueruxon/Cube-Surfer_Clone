using UnityEngine;
using PathCreation;


public class PathFollower : MonoBehaviour
{
    [SerializeField] private PathCreator _pathCreator;
    [SerializeField] private float _speed = 15f;

    private float _passedPath;
    private EndOfPathInstruction _endPath = EndOfPathInstruction.Stop;

    private void Update() {
        if (GameManager.Instance.CurrentGameState == GameState.Started) {
            MovingAndRotate();
        }
    }

    private void StopMoving() {
        _speed = 0f;
    }

    private void MovingAndRotate() {
        _passedPath += _speed * Time.deltaTime;

        transform.position = _pathCreator.path.GetPointAtDistance(_passedPath, _endPath);
        transform.rotation = _pathCreator.path.GetRotationAtDistance(_passedPath, _endPath);
    }
}
