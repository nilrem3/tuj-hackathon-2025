using UnityEngine;

public class CurveRenderer : MonoBehaviour
{
    const double Z_VALUE = -0.01;
    const double LEFT_EDGE = -0.5;
    const double RIGHT_EDGE = 0.5;
    const double TOP_EDGE = 0.5;
    const double BOTTOM_EDGE = -0.5;

    private LineRenderer lr;

    public BrightnessCurve curve;

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
        lr.positionCount = this.curve.values.Length;
        double horizontalStep = (RIGHT_EDGE - LEFT_EDGE) / (this.curve.values.Length - 1);
        double verticalStep = (TOP_EDGE - BOTTOM_EDGE) / 100;
        for (int i = 0; i < this.curve.values.Length; i++) {
            Vector3 point = new Vector3((float)(LEFT_EDGE + horizontalStep * i), (float)(BOTTOM_EDGE + verticalStep * this.curve.values[i]), (float)Z_VALUE);
            lr.SetPosition(i, point);
        }
    }
}
