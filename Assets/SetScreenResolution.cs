using UnityEngine;

public class SetScreenResolution : MonoBehaviour
{
    [SerializeField] private Vector2Int _resolution;
    private void Awake()
    {
        Screen.SetResolution(_resolution.x, _resolution.y, true);
    }
}
