using UnityEngine;

public class OnlyInEditor : MonoBehaviour
{
    private void OnEnable() => gameObject.SetActive(Application.isEditor);
}
