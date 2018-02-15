using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Character
{
    protected override void MovePlayer()
    {
        Debug.Log("My Version of move player");
        base.MovePlayer();
    }

    private void Update()
    {
        MovePlayer();
    }
}
