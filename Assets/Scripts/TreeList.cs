using System.Collections.Generic;
using UnityEngine;

public class TreeList : MonoBehaviour {
    public GameObject[] treeObjects;
    public string[] treeNames = { "Дуб", "Ясень", "Береза" };

    public Dictionary<string, GameObject> customTreeObjects;
}