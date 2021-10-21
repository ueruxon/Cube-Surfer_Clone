using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CubePool : MonoBehaviour
{
    public event UnityAction<int> CubesCountChanged;

    [SerializeField] private CollectedCube _pfTemplate;
    [SerializeField] private Transform _spawnPosition;

    private List<CollectedCube> _attachedCubeList;

    private void Awake() {
        _attachedCubeList = new List<CollectedCube>();
    }

    public void AddCube() {
        Vector3 spawnPosition = GetSpawnPosition();

        CollectedCube newCube = Instantiate(_pfTemplate);
        newCube.CubeRemoved += OnCubeRemoved;
        newCube.Init(spawnPosition, Quaternion.identity, transform);

        _attachedCubeList.Add(newCube);

        CubesCountChanged?.Invoke(_attachedCubeList.Count);
    }

    private void OnCubeRemoved(CollectedCube cube) {
        _attachedCubeList.Remove(cube);
        cube.CubeRemoved -= OnCubeRemoved;
        cube.Remove();

        CubesCountChanged?.Invoke(_attachedCubeList.Count);
    }

    public void RemoveCube(CollectedCube cube) {
        _attachedCubeList.Remove(cube);
        cube.Remove();

        CubesCountChanged?.Invoke(_attachedCubeList.Count);
    }

    private Vector3 GetSpawnPosition() {
        Vector3 spawnPoint = _spawnPosition.localPosition;
        _spawnPosition.localPosition += Vector3.up;
        return spawnPoint;
    }
}
