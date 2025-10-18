using UnityEngine;

[CreateAssetMenu(fileName = "Body", menuName = "Scriptable Objects/Body")]
public class Body : ScriptableObject
{
    public int sizeActual;
    public int distanceActual;
    
    public MeshFilter meshFilter;
    public BrightnessCurve brightnessCurve;
    
    public MeshRenderer meshRenderer;
    public LightQuality lightQuality;

    public int luminosityTotal;
}
