using System;
using System.IO;
using UnityEngine;
using AnotherFileBrowser.Windows;
using UnityEngine.Events;

public class TreesFileLoader : MonoBehaviour {
    [SerializeField] private char[] separators = { '|' };
    [SerializeField] private TreeList treeList;

    public static event UnityAction GotSuccessfulLoad;

    public void OpenFileBrowser() {
        var bp = new BrowserProperties();
        new FileBrowser().OpenFileBrowser(bp, path => {
            Debug.Log(path);
            LoadTrees(path);
            GotSuccessfulLoad?.Invoke();
        });
    }

    private void LoadTrees(string path) {
        var text = File.ReadAllText(path);
        var treeInfo = text.Split(separators);

        foreach (var tree in treeInfo) {
            var components = tree.Split(',');

            var objCoordinates = new Vector3 {
                x = float.Parse(components[4]),
                y = 0f,
                z = float.Parse(components[5])
            };

            var woodTypeIndex = Array.IndexOf(treeList.treeNames, components[0]);

            Instantiate(treeList.treeObjects[woodTypeIndex], objCoordinates, Quaternion.identity);

            Debug.Log("Порода: " + treeList.treeNames[woodTypeIndex] + " Возраст: " + components[1] + " Диаметр: " +
                      components[2] + " Высота: " + components[3]);
        }
    }
}