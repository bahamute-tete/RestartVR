using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePointConnect : MonoBehaviour
{
    [SerializeField] GameObject targetPoint;
    public Color lineColor = new Color32(255, 255, 255, 255);
    public float lineWidth = 0.04f;
    LineRenderer lr ;
    // Start is called before the first frame update
    private void Awake()
    {
        LineRenderSet();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, gameObject.transform.position);
        lr.SetPosition(1, targetPoint.transform.position);
        lr.startWidth = lr.endWidth = lineWidth;
        lr.startColor = lr.endColor = lineColor;
    }

    void LineRenderSet()
    {
        lr = gameObject.AddComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        lr.material = new Material(Shader.Find("Particles/Standard Unlit"));
        lr.startWidth = lr.endWidth = lineWidth;
        lr.startColor = lr.endColor = lineColor;
    }
}
