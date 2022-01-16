using UnityEngine;

public class ModelSpawner : MonoBehaviour
{
    [SerializeField]
    private SpawnPositionChecker spawnPositionChecker = default;

    [SerializeField]
    private GameObject prefab = default;

    [SerializeField]
    private Transform parent = default;

    private GameObject model = null;

    public void Spawn()
    {
        if (spawnPositionChecker.IsPositionFound == false)
        {
            return;
        }

        if (model)
        {
            model.SetActive(false);

            model.transform.position = spawnPositionChecker.SpawnPosition;
            model.transform.eulerAngles = GetModelEuler();

            model.SetActive(true);

            return;
        }

        model = Instantiate(prefab,
            spawnPositionChecker.SpawnPosition,
            GetModelQuaternion(),
            parent);
    }

    private Quaternion GetModelQuaternion()
    {
        Quaternion quaternion = new Quaternion();

        quaternion.eulerAngles = GetModelEuler();

        return quaternion;
    }

    private Vector3 GetModelEuler()
    {
        return new Vector3(0, (Camera.main.transform.eulerAngles.y + 180) % 360, 0);
    }
}
