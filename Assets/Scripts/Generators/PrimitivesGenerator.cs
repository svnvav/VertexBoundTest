using System.Collections.Generic;
using UnityEngine;

namespace Plarium.VGO
{
    public class PrimitivesGenerator : MeshGeneratorBase
    {
        [SerializeField] private Mesh[] _primitives;

        private List<GameObject> _meshHolders = new List<GameObject>();
        private int _vertexCount;

        public override void Generate(int vertexCount)
        {
            var counter = 0;
            while (counter < vertexCount)
            {
                var position = Random.insideUnitCircle * 2;
                var meshHolder = Instantiate(_meshHolderPrefab);
                meshHolder.transform.position = position;
                _meshHolders.Add(meshHolder);
                var mf = meshHolder.GetComponent<MeshFilter>();
                mf.sharedMesh = _primitives[Random.Range(0, _primitives.Length - 1)];
                counter += mf.sharedMesh.vertexCount;
            }

            _vertexCount = counter;
        }

        public override void Clear()
        {
            foreach (var meshHolder in _meshHolders)
            {
                Destroy(meshHolder);
            }

            _meshHolders.Clear();
        }
        
        public override int GetVertexCount()
        {
            return _vertexCount;
        }
    }
}