using UnityEngine;

public class CollectableRadar : MonoBehaviour
{
    [SerializeField] private CubePool _cubePool;

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out CollectableCube cube)) {
            other.gameObject.SetActive(false);
            _cubePool.AddCube();
        }
    }
}
