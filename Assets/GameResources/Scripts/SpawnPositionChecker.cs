using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SpawnPositionChecker : MonoBehaviour
{
    public event Action SpawnPositionChanged;
    public event Action<bool> SpawnPositionFound;

    [SerializeField]
    private ARRaycastManager arRaycastManager = default;

    private bool isPositionFound = false;
    public bool IsPositionFound
    {
        get
        {
            return isPositionFound;
        }

        set
        {
            isPositionFound = value;

            SpawnPositionFound?.Invoke(isPositionFound);
        }
    }

    private Vector3 spawnPosition = Vector3.zero;
    public Vector3 SpawnPosition
    {
        get
        {
            return spawnPosition;
        }

        set
        {
            spawnPosition = value;

            SpawnPositionChanged?.Invoke();
        }
    }

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private Vector3 hitPosition = Vector3.zero;

    private void Update()
    {
        CheckPosition();
    }

    private void CheckPosition()
    {
        IsPositionFound = Raycast();

        if (!IsPositionFound)
        {
            return;
        }

        SpawnPosition = hitPosition;
    }

    private bool Raycast()
    {
        bool result;

        if (Application.isEditor)
        {
            result = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 25.0f);

            hitPosition = hit.point;

            return result;
        }

        hits.Clear();

        result = arRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        hitPosition = hits[0].pose.position;

        return result;
    }
}
