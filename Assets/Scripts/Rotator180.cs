using UnityEngine;

namespace Plarium.VGO
{
    public class Rotator180 : MonoBehaviour
    {
        public void Rotate()
        {
            transform.Rotate(Vector3.up, 180);
        }
    }
}