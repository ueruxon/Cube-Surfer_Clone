using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CollectedCube : MonoBehaviour
{
    public event UnityAction<CollectedCube> CubeRemoved;

    private Rigidbody _rb;

    private void Start() {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out Obstacle obstacle)) {
            CubeRemoved?.Invoke(this);
        }
    }

    public void Init(Vector3 spawnPosition, Quaternion spawnRotation, Transform parent) {
        transform.SetParent(parent);
        transform.localPosition = spawnPosition;
        transform.localRotation = spawnRotation;
    }

    public void Remove() {
        transform.SetParent(null);

        StartCoroutine(RemoveCo());
    }

    private IEnumerator RemoveCo() {
        _rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(3f);
        transform.position = Vector3.zero;
        gameObject.SetActive(false);
    }
}
