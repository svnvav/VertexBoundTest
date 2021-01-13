using UnityEngine;
using UnityEngine.UI;

namespace Plarium.VGO
{
    public class FPSDisplay : MonoBehaviour
    {
        [SerializeField] private Text _fpsText;
        [SerializeField] private float _refreshRate = 1f;
 
        private float _timer;

        public void Update ()
        {
            if (Time.unscaledTime > _timer)
            {
                var fps = (int)(1f / Time.unscaledDeltaTime);
                _fpsText.text = $"FPS: {fps}";
                _timer = Time.unscaledTime + _refreshRate;
            }
        }
    }
}