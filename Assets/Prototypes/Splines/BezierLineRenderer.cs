using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public sealed class BezierLineRenderer : MonoBehaviour
{
    public Color c1 = Color.yellow;
    public Color c2 = Color.red;

    [SerializeField]
    private Transform A;
    [SerializeField]
    private Transform B;
    [SerializeField]
    private Transform C;
    [SerializeField]
    private Transform D;

    private BezierInterpolator bezier = new BezierInterpolator();
    private List<Tuple<Vector3, Vector3>> lines = new List<Tuple<Vector3, Vector3>>();

    private void Awake()
    {
        if (A != null && B != null && C != null && D != null)
        {

            bezier.Interpolate(
                A.position, B.position, C.position, D.position,
                lines
            );

            var lineRenderer = GetComponent<LineRenderer>();

            lineRenderer.positionCount = lines.Count + 1;

            // A simple 2 color gradient with a fixed alpha of 1.0f.
            float alpha = 1.0f;
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
                );
            lineRenderer.colorGradient = gradient;

            if (lines.Count > 0)
            {
                lineRenderer.SetPosition(0, lines[0].a);

                for (int i = 0; i < lines.Count; i++)
                {
                    var line = lines[i];
                    lineRenderer.SetPosition(i + 1, line.a);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        bezier.Interpolate(
            A.position, B.position, C.position, D.position,
            lines
        );

        Gizmos.DrawCube(A.position, Vector3.one * .1f);
        Gizmos.DrawCube(B.position, Vector3.one * .1f);
        Gizmos.DrawCube(C.position, Vector3.one * .1f);
        Gizmos.DrawCube(D.position, Vector3.one * .1f);

        //The Bezier curve's color
        Gizmos.color = Color.white;

        foreach (var line in lines)
        {
            //Draw this line segment
            Gizmos.DrawLine(line.a, line.b);
        }

        //Also draw lines between the control points and endpoints
        Gizmos.color = Color.green;

        Gizmos.DrawLine(A.position, B.position);
        Gizmos.DrawLine(C.position, D.position);
    }
}