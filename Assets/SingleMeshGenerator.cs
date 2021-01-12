using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace DefaultNamespace
{
    public class SingleMeshGenerator : MeshGenerator
    {
        private GameObject _meshHolder;

        public override void Clear()
        {
            Destroy(_meshHolder);
            _meshHolder = null;
        }

        public override void Generate(int vertexCount)
        {
            var nearestSqrt = Mathf.FloorToInt(Mathf.Sqrt(vertexCount));
            var n = nearestSqrt;
            var m = vertexCount / n;
            var r = vertexCount - m * n;

            var vertices = new Vector3[vertexCount];
            var h = 2f / n;
            for (int i = 0; i < n; i++)
            {
                var x = -1 + h * i;
                for (int j = 0; j < m; j++)
                {
                    var y = -1 + h * j;
                    vertices[i * m + j] = new Vector3(x, y, 0);
                }
            }

            var trianglesList = new List<int>(vertexCount * 3);
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    var ti00 = (i - 1) * m + j - 1;
                    var ti01 = (i - 1) * m + j;
                    var ti10 = i * m + j - 1;
                    var ti11 = i * m + j;
                    
                    trianglesList.AddRange(new []{ti00, ti01, ti10});
                    trianglesList.AddRange(new []{ti10, ti01, ti11});
                }
            }
            
            var mesh = new Mesh();
            mesh.indexFormat = vertexCount > Mathf.Pow(2, 15) ? IndexFormat.UInt32 : IndexFormat.UInt16;
            mesh.SetVertices(vertices);
            mesh.triangles = trianglesList.ToArray();

            _meshHolder = Instantiate(_meshHolderPrefab);
            var mf = _meshHolder.GetComponent<MeshFilter>();
            mf.sharedMesh = mesh;
        }
    }
}