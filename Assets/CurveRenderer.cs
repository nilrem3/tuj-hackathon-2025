using UnityEngine;

public class CurveRenderer : MonoBehaviour
{
    const double Z_VALUE = -0.025;
    const double LEFT_EDGE = -0.5;
    const double RIGHT_EDGE = 0.5;
    const double TOP_EDGE = 0.5;
    const double BOTTOM_EDGE = -0.5;

    private LineRenderer lr;

    public Curve curve;

    void Awake() {
        lr = GetComponent<LineRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        setPoints();
    }

    public void setPoints() {
        setPointsFromArray(this.curve.values);
    }

    public void setPointsFromArray(int[] array) {
        lr.positionCount = array.Length;
        double horizontalStep = (RIGHT_EDGE - LEFT_EDGE) / (array.Length - 1);
        double verticalStep = (TOP_EDGE - BOTTOM_EDGE) / 100;
        for (int i = 0; i < array.Length; i++) {
            Vector3 point = new Vector3((float)(LEFT_EDGE + horizontalStep * i), (float)(BOTTOM_EDGE + verticalStep * array[i]), (float)Z_VALUE);
            lr.SetPosition(i, point);
        }
    }
}
