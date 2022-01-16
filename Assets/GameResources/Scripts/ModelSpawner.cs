using System.Collections;
using System.Collections.Generic;
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
            Destroy(model);
        }

        model = Instantiate(prefab,
            spawnPositionChecker.SpawnPosition,
            GetModelRotation(),
            parent);
    }

    private Quaternion GetModelRotation()
    {
        var quaternion = new Quaternion();

        quaternion.eulerAngles = new Vector3(0, (Camera.main.transform.eulerAngles.y + 180) % 360, 0);

        return quaternion;
    }
}
