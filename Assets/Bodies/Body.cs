using UnityEngine;

[CreateAssetMenu(fileName = "Body", menuName = "Scriptable Objects/Body")]
public class Body : ScriptableObject
{
    public enum Shape
    {
        Sphere = 0,
        Cylinder = 1,
        Box = 2,
        Lumpy = 3,
    }

    public enum Material
    {
        Ice = 0,
        Iron = 1,
        Gravel = 2,
        Hydrogen = 3, 
        VolcanicAsh = 4,
        Wood = 5,
    }
    
    public int sizeActual;
    public int distanceActual;
    
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;
    
    public Shape shape;
    public Material material;
    public Curve brightnessCurve;
    
    public Curve lightQuality;

    public int luminosityTotal;
}
