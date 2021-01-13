using UnityEngine;

namespace Plarium.VGO
{
    public abstract class MeshGenerator : MonoBehaviour
    {
        [SerializeField] protected GameObject _meshHolderPrefab;
        public abstract void Generate(int vertexCount);

        public abstract void Clear();
    }
}