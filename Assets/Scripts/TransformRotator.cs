using UnityEngine;

namespace Plarium.VGO
{
    public class TransformRotator : MonoBehaviour
    {
        [SerializeField] private float _degreesPerSecond;

        private int _rotationDir = 0;
        
        private void Update()
        {
           transform.Rotate(Vector3.up, _rotationDir * _degreesPerSecond * Time.deltaTime);
        }

        public void StartRotateLeft()
        {
            _rotationDir = -1;
        }
        
        public void StartRotateRight()
        {
            _rotationDir = 1;
        }
        
        public void StopRotate()
        {
            _rotationDir = 0;
        }
    }
}