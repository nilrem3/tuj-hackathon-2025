using UnityEngine;

[CreateAssetMenu(fileName = "Body", menuName = "Scriptable Objects/Body")]
public class Body : ScriptableObject
{
    public enum ShapeDef
    {
        Sphere = 0,
        Cylinder = 1,
        Box = 2,
        Lumpy = 3,
    }

    public enum MaterialDef
    {
        Ice = 0,
        Iron = 1,
        Gravel = 2,
        Hydrogen = 3, 
        VolcanicAsh = 4,
        Wood = 5,
    }

    public Vector3 positionOffset;
    public float scaleOffset;
    
    public int sizeActual;
    public int distanceActual;
    
    public Mesh mesh;
    public Material material;
    
    public ShapeDef shapeDef;
    public MaterialDef materialDef;
    public Curve brightnessCurve;
    
    public Curve lightQuality;

    public int luminosityTotal;
}
