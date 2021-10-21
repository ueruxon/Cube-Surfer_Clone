using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public float HorizontalDelta{ get; private set; }
    private float MouseToScreenPoint { get { return Screen.width / 2f * 0.3f; } }

    private float _touchPosition;
    private bool _isFirstTouch = true;

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (_isFirstTouch) {
                // вынести в другое место
                GameManager.Instance.StartGame();
                _isFirstTouch = false;
            }

            _touchPosition = Input.mousePosition.x;
        }

        if (Input.GetMouseButton(0)) {
            float deltaX = (Input.mousePosition.x - _touchPosition) / MouseToScreenPoint;
            float clampedDelta = Mathf.Clamp(deltaX, -1f, 1f);

            HorizontalDelta = clampedDelta;
        }
    }
}
