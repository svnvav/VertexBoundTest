using System.Collections.Generic;
using UnityEngine;

namespace Plarium.VGO
{
    public class ManyLittleMeshesGenerator : MeshGeneratorBase
    {
        private List<GameObject> _meshHolders = new List<GameObject>();

        private int _vertexCount;

        public override void Generate(int vertexCount)
        {
            var mesh = GetSimpleMesh();

            var objectsCount = vertexCount / mesh.vertexCount;

            var nearestSqrt = Mathf.FloorToInt(Mathf.Sqrt(objectsCount));
            var n = nearestSqrt;
            var m = objectsCount / n;
            if (objectsCount > m * n) m++;

            var h = 3.2f / n;

            for (int i = 0; i < n; i++)
            {
                var x = -1 + h * i;
                for (int j = 0; j < m; j++)
                {
                    if (i * m + j >= objectsCount) break;

                    var y = -1 + h * j;
                    var position = new Vector3(x, y, 0);
                    var meshHolder = Instantiate(_meshHolderPrefab);
                    meshHolder.transform.position = position;
                    _meshHolders.Add(meshHolder);
                    var mf = meshHolder.GetComponent<MeshFilter>();
                    mf.sharedMesh = mesh;
                }
            }

            _vertexCount = objectsCount * mesh.vertexCount;
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

        private Mesh GetSimpleMesh()
        {
            var mesh = new Mesh();
            
            mesh.SetVertices(new Vector3[]
            {
                new Vector3(-0.5f, -0.5f, 0),
                new Vector3(-0.5f, 0.5f, 0),
                //new Vector3(0, 0, 0),
                new Vector3(0.5f, -0.5f, 0),
                new Vector3(0.5f, 0.5f, 0),
            });
            mesh.triangles = new int[]
            {
                0, 2, 1, //для количества
                0, 1, 2,
                1,3,2,
                1,2,3
                /*2, 1, 4,
                2, 4, 3,
                2, 3, 0*/
            };
            var uv = new Vector2[]
            {
                new Vector2(0, 0),
                new Vector2(0, 1),
                //new Vector2(0.5f, 0.5f), 
                new Vector2(1, 0),
                new Vector2(1, 1)
            };
            mesh.SetUVs(0, uv);
            mesh.SetUVs(1, uv);

            return mesh;
        }
    }
}