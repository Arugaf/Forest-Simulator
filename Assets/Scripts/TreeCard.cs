using System;
using TMPro;
using UnityEngine;

public class TreeCard : MonoBehaviour {
    public TMP_Text WoodType;
    public TMP_Text Age;
    public TMP_Text Diameter;
    public TMP_Text Height;

    public GameObject Tree = null;

    private bool _selected = false;

    public void Awake() {
        WoodType = transform.Find("Wood Type").GetComponent<TMP_Text>();
        Age = transform.Find("Age").GetComponent<TMP_Text>();
        Diameter = transform.Find("Diameter").GetComponent<TMP_Text>();
        Height = transform.Find("Height").GetComponent<TMP_Text>();
    }

    // Ray ray;
    // RaycastHit hit;

    void Update() {
        // todo
        /*if (!GetComponent<MeshRenderer>()) return;
        if (!Input.GetMouseButtonDown(0)) return;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out hit)) {
            _selected = false;
            OnMouseExit();
        }*/
    }

    /*public void OnMouseDown() {
        GetComponent<MeshRenderer>().material.color = Color.red;
        _selected = true;
    }

    public void OnMouseEnter() {
        if (_selected) return;
        GetComponent<MeshRenderer>().material.color = Color.cyan;
    }

    public void OnMouseExit() {
        if (_selected) return;
        GetComponent<MeshRenderer>().material.color = new Color(204, 204, 204, 1.0f);
    }*/
}