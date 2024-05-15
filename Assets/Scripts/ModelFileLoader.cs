using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using AnotherFileBrowser.Windows;
using UnityEngine.Events;
using Dummiesman;

public class ModelFileLoader : MonoBehaviour {
    [SerializeField] private TreeList treeList;

    // public static event UnityAction GotSuccessfulTreeListLoad;

    public void OpenFileBrowser() {
        var bp = new BrowserProperties();
        new FileBrowser().OpenMultiSelectFileBrowser(bp, paths => {
            foreach (var model in paths) {
                Debug.Log(model);
            }

            LoadTrees(paths);
        });
    }

    private void LoadTrees(string[] paths) {
        treeList.CustomTreeObjects = new Dictionary<string, GameObject>();
        
        foreach (var file in paths) {
            var fileName = Path.GetFileNameWithoutExtension(file);
            Debug.Log(fileName);
            
            var objFile = new OBJLoader().Load(file);
            DontDestroyOnLoad(objFile);
            
            treeList.CustomTreeObjects.Add(fileName, objFile);
        }
    }
}