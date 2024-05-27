#if UNITY_EDITOR
using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class MeshCombines : MonoBehaviour
{
    [SerializeField] private string folderPath = "Assets/Meshes";

    [ContextMenu("Save Combined Mesh")]
    private void CreateMesh()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        foreach (MeshFilter filter in meshFilters)
        {
            Mesh mesh = filter.sharedMesh; 

            if (mesh != null)
            {
                string fileName = Guid.NewGuid() + ".asset"; 
                string filePath = Path.Combine(folderPath, fileName); 
                
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    AssetDatabase.Refresh(); 
                }
                
                AssetDatabase.CreateAsset(mesh, filePath);
                Debug.Log("Mesh saved: " + filePath);
            }
        }
    }
}
#endif
