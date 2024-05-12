using System;
using TMPro;
using UnityEngine;

public class TreeCard : MonoBehaviour {
    public TMP_Text WoodType;
    public TMP_Text Age;
    public TMP_Text Diameter;
    public TMP_Text Height;

    public void Awake() {
        WoodType = transform.Find("Wood Type").GetComponent<TMP_Text>();
        Age = transform.Find("Age").GetComponent<TMP_Text>();
        Diameter = transform.Find("Diameter").GetComponent<TMP_Text>();
        Height = transform.Find("Height").GetComponent<TMP_Text>();
    }
}