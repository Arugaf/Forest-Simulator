using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeSpawner : MonoBehaviour {
    public static TreeSpawner Instance;

    [SerializeField] private TreeList treeList;

    private List<Tree> _trees;

    public List<Tree> GetTrees() {
        return _trees;
    }

    public void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);
        }
        else {
            Instance = this;
        }

        DontDestroyOnLoad(transform.gameObject);
    }

    public void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void Initialize(List<Tree> trees) {
        _trees = trees;
    }

    public void SpawnTrees() {
        if (_trees == null) return;
        foreach (var tree in _trees) {
            Instantiate(treeList.treeObjects[tree.WoodTypeIndex], tree.Coordinates, Quaternion.identity);

            Debug.Log("Порода: " + tree.WoodType + " Возраст: " + tree.Age + " Диаметр: " +
                      tree.Diameter + " Высота: " + tree.Height);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name != "MainScene") return; // todo
        SpawnTrees();
    }
}