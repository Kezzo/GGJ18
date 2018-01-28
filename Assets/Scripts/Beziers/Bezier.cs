using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// http://www.habrador.com/tutorials/interpolation/2-bezier-curve/
public class Bezier : MonoBehaviour
{
    //Has to be at least 4 so-called control points
    public Transform startPoint;
    public Transform endPoint;
    public Transform controlPointStart;
    public Transform controlPointEnd;

    private BezierInterpolator bezier = new BezierInterpolator();
    private List<Tuple<Vector3, Vector3>> lines = new List<Tuple<Vector3, Vector3>>();

    //Display without having to press play
    void OnDrawGizmos()
    {
        var A = startPoint.position;
        var B = controlPointStart.position;
        var C = controlPointEnd.position;
        var D = endPoint.position;

        bezier.Interpolate(
            A, B, C, D,
            lines
        );

        //The Bezier curve's color
        Gizmos.color = Color.white;

        foreach (var line in lines)
        {
            //Draw this line segment
            Gizmos.DrawLine(line.a, line.b);
        }

        //Also draw lines between the control points and endpoints
        Gizmos.color = Color.green;

        Gizmos.DrawLine(A, B);
        Gizmos.DrawLine(C, D);
    }
}

//Interpolation between 2 points with a Bezier Curve (cubic spline)
public class BezierInterpolator
{
    Vector3 A, B, C, D;

    // The resolution of the line
    // Make sure the resolution is adding up to 1, so 0.3 will give a gap at the end, but 0.2 will work

    public void Interpolate(
        Vector3 A, Vector3 B, Vector3 C, Vector3 D,
        List<Tuple<Vector3, Vector3>> lines, float resolution = 0.02f)
    {
        this.A = A;
        this.B = B;
        this.C = C;
        this.D = D;

        lines.Clear();

        //The start position of the line
        Vector3 lastPos = A;

        //How many loops?
        int loops = Mathf.FloorToInt(1f / resolution);

        for (int i = 1; i <= loops; i++)
        {
            //Which t position are we at?
            float t = i * resolution;

            //Find the coordinates between the control points with a Catmull-Rom spline
            Vector3 newPos = DeCasteljausAlgorithm(t);

            lines.Add(new Tuple<Vector3, Vector3>(lastPos, newPos));

            //Save this pos so we can draw the next line segment
            lastPos = newPos;
        }
    }

    //The De Casteljau's Algorithm
    Vector3 DeCasteljausAlgorithm(float t)
    {
        //Linear interpolation = lerp = (1 - t) * A + t * B
        //Could use Vector3.Lerp(A, B, t)

        //To make it faster
        float oneMinusT = 1f - t;

        //Layer 1
        Vector3 Q = oneMinusT * A + t * B;
        Vector3 R = oneMinusT * B + t * C;
        Vector3 S = oneMinusT * C + t * D;

        //Layer 2
        Vector3 P = oneMinusT * Q + t * R;
        Vector3 T = oneMinusT * R + t * S;

        //Final interpolated position
        Vector3 U = oneMinusT * P + t * T;

        return U;
    }
}
