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

    protected override void Jump()
    {
        Anim.SetFloat("velY", Rb2D.velocity.y);
        Anim.SetBool("isLanding", IsLanding);
        if (Btn_jump)
        {
            GameManager.instance.PlaySFX(0);
            base.Jump();
            Anim.SetTrigger("jump");
        }
    }

    private new void Update()
    {
        base.Update();
        MovePlayer();
        Jump();
    }
}
