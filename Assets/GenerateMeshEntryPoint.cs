using System;
using System.Linq;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class GenerateMeshEntryPoint : MonoBehaviour
{
    [SerializeField] private InputField _vertexCountInput;
    [SerializeField] private ToggleGroup _toggleGroup;

    private MeshGenerator _last;

    public void Generate()
    {
        var vertexCount = 0;
        try
        {
            vertexCount = int.Parse(_vertexCountInput.text);
        }
        catch (Exception e) {/*ignored*/}

        if(vertexCount <= 0) return;
        
        if(_last != null) _last.Clear();

        _last = _toggleGroup.ActiveToggles().First().GetComponent<MeshGenerator>();
        _last.Generate(vertexCount);
    }
}
