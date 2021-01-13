using UnityEngine;

public class SetScreenResolution : MonoBehaviour
{
    [SerializeField] private Vector2Int _resolution;
    private void Start()
    {
        Screen.SetResolution(_resolution.x, _resolution.y, true);
    }
}
