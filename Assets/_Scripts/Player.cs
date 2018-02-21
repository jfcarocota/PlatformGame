using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Character
{
    protected override void MovePlayer()
    {
        base.MovePlayer();
        Anim.SetFloat("axisX", Mathf.Abs(Axis.x));
    }

    private new void Update()
    {
        base.Update();
        MovePlayer();
        Jump();
    }
}
