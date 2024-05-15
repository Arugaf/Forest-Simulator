using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using AnotherFileBrowser.Windows;
using UnityEngine.Events;

public class TreesFileLoader : MonoBehaviour {
    [SerializeField] private char[] separators = { '|' };
    [SerializeField] private TreeList treeList;
    [SerializeField] private TreeSpawner treeSpawner;

    private List<Tree> _trees;

    public static event UnityAction GotSuccessfulTreeListLoad;

    public void OpenFileBrowser() {
        var bp = new BrowserProperties();
        new FileBrowser().OpenFileBrowser(bp, path => {
            Debug.Log(path);
            LoadTrees(path);

            if (treeSpawner != null) {
                treeSpawner.Initialize(_trees);
            }

            GotSuccessfulTreeListLoad?.Invoke();
        });
    }

    private void LoadTrees(string path) {
        _trees = new List<Tree>();

        var text = File.ReadAllText(path);
        var treeInfo = text.Split(separators);

        foreach (var tree in treeInfo) {
            var components = tree.Split(',');

            var objCoordinates = new Vector3 {
                x = float.Parse(components[4], CultureInfo.InvariantCulture),
                y = 0f,
                z = float.Parse(components[5], CultureInfo.InvariantCulture)
            };

            var woodTypeIndex = -1;
            var contains = false;
            if (treeList.CustomTreeObjects != null) {
                contains = treeList.CustomTreeObjects.ContainsKey(components[0]);
            }

            if (!contains) {
                woodTypeIndex = Array.IndexOf(treeList.treeNames, components[0]);
            }

            // todo: error check

            _trees.Add(new Tree(
                objCoordinates,
                components[0],
                woodTypeIndex == -1 ? -1 : woodTypeIndex,
                float.Parse(components[1], CultureInfo.InvariantCulture),
                float.Parse(components[2], CultureInfo.InvariantCulture),
                float.Parse(components[3], CultureInfo.InvariantCulture)));
        }
    }
}