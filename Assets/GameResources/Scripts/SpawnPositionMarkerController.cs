using UnityEngine;

public class SpawnPositionMarkerController : MonoBehaviour
{
    [SerializeField]
    private SpawnPositionChecker spawnPositionChecker = default;

    [SerializeField]
    private GameObject marker = default;

    private void OnEnable()
    {
        spawnPositionChecker.SpawnPositionChanged += OnSpawnPositionChanged;
        spawnPositionChecker.SpawnPositionFound += OnPositionFound;
    }

    private void OnDisable()
    {
        spawnPositionChecker.SpawnPositionChanged -= OnSpawnPositionChanged;
        spawnPositionChecker.SpawnPositionFound -= OnPositionFound;
    }

    private void OnSpawnPositionChanged()
    {
        marker.transform.position = spawnPositionChecker.SpawnPosition;
    }

    private void OnPositionFound(bool status)
    {
        marker.SetActive(status);
    }
}
