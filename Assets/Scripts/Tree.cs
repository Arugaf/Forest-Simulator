using UnityEngine;

public struct Tree {
    public Vector3 Coordinates;
    public string WoodType;
    public int WoodTypeIndex;
    public float Age;
    public float Diameter;
    public float Height;

    public Tree(Vector3 coordinates, string woodType, int woodTypeIndex, float age, float diameter, float height) {
        Coordinates = coordinates;
        WoodType = woodType;
        WoodTypeIndex = woodTypeIndex;
        Age = age;
        Diameter = diameter;
        Height = height;
    }
}