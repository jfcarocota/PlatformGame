using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    protected override void Jump(Rigidbody2D Rb2D, float jumpForce)
    {
        Anim.SetFloat("velY", Rb2D.velocity.y);
        Anim.SetBool("isLanding", IsLanding);
        if (Btn_jump(IsLanding))
        {
            GameManager.instance.PlaySFX(0);
            base.Jump(Rb2D, jumpForce);
            Anim.SetTrigger("jump");
        }
    }

    protected override void MovePlayer(Rigidbody2D rb2D, float moveSpeed, Vector2 clampedVel, float limitVel, bool isLanding)
    {
        base.MovePlayer(rb2D, moveSpeed, clampedVel, limitVel, isLanding);
        Anim.SetFloat("axisX", Mathf.Abs(Axis.x));
    }

    private new void Update()
    {
        base.Update();
        MovePlayer(Rb2D, MoveSpeed, ClampedVel, LimitVel, IsLanding);
        Jump(Rb2D, JumpForce);
    }
}
