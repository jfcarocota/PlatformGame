using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Character
{
    protected override void MovePlayer()
    {
        base.MovePlayer();

    }

    private new void Update()
    {
        base.Update();
        MovePlayer();
        Jump();
    }
}
