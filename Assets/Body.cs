using UnityEngine;

[CreateAssetMenu(fileName = "Body", menuName = "Scriptable Objects/Body")]
public class Body : ScriptableObject
{
    public int sizeActual;
    public int distanceActual;
    
    public MeshFilter meshFilter;
    public int[] brightnessCurve;
    
    public MeshRenderer meshRenderer;
    public int[] lightQuality;

    public int luminosityTotal;
}
