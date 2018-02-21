using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class JumpSystem
{
    [SerializeField]
    Color rayColor = Color.red;
    [SerializeField, Range(0.1f, 10f)]
    float rayDistance;
    [SerializeField]
    LayerMask groundLayer;

    RaycastHit2D hit;

    public Color RayColor
    {
        get
        {
            return rayColor;
        }

        set
        {
            rayColor = value;
        }
    }

    public float RayDistance
    {
        get
        {
            return rayDistance;
        }

        set
        {
            rayDistance = value;
        }
    }

    public LayerMask GroundLayer
    {
        get
        {
            return groundLayer;
        }

        set
        {
            groundLayer = value;
        }
    }

    public bool IsLanding(Vector2 fromPos)
    {
        return Physics2D.Raycast(fromPos, Vector2.down, rayDistance, groundLayer);
    }
}
