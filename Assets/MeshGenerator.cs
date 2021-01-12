using UnityEngine;

namespace DefaultNamespace
{
    public abstract class MeshGenerator : MonoBehaviour
    {
        [SerializeField] protected GameObject _meshHolderPrefab;
        public abstract void Generate(int vertexCount);

        public abstract void Clear();
    }
}