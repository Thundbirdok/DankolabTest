using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class SetMainCameraAsTarget : MonoBehaviour
{
    [SerializeField]
    private MultiAimConstraint multiAimConstraint = default;

    [SerializeField]
    private RigBuilder rigBuilder = default;

    private void OnEnable()
    {
        MultiAimConstraintData data = multiAimConstraint.data;

        data.sourceObjects.SetTransform(0, Camera.main.transform);

        multiAimConstraint.data = data;

        rigBuilder.Build();
    }
}
