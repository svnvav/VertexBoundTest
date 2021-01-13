using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Plarium.VGO
{
    public class GenerateMeshEntryPoint : MonoBehaviour
    {
        [SerializeField] private InputField _vertexCountInput;
        [SerializeField] private ToggleGroup _toggleGroup;
        [SerializeField] private Text _vertexCountText;

        private MeshGeneratorBase _last;

        public void Generate()
        {
            var vertexCount = 0;
            try
            {
                vertexCount = int.Parse(_vertexCountInput.text);
            }
            catch (Exception e)
            {
                /*ignored*/
            }

            if (vertexCount <= 0) return;

            if (_last != null) _last.Clear();

            _last = _toggleGroup.ActiveToggles().First().GetComponent<MeshGeneratorBase>();
            _last.Generate(vertexCount);
            _vertexCountText.text = $"Vertices: {_last.GetVertexCount()}";
        }
    }
}
