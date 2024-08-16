using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineAtoB : MonoBehaviour
{
    private LineRenderer line;
    Vector2 start;
    Transform end;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();

        line.positionCount = 2;
        line.enabled = false;
    }

    public void StartPos(Vector2 start, Transform end)
    {
        line.enabled = true;
        line.SetPosition(0, start);
        this.end = end;
    }

    private void Update()
    {
        if (line.enabled)
        {
            line.SetPosition(1, end.position);
        }
    }

    public void ChangeEnabled()
    {
        line.enabled = false;
    }
}
