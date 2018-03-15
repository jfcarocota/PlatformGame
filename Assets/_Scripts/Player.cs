using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;


public class Player : Character
{
    protected override void Jump(Rigidbody2D Rb2D, float jumpForce)
    {
        Anim.SetFloat("velY", Rb2D.velocity.y);
        Anim.SetBool("isLanding", IsLanding);
        if (Btn_jump(IsLanding))
        {
            GameManager.instance.PlaySFX(0, 0.2f);
            base.Jump(Rb2D, jumpForce);
            Anim.SetTrigger("jump");
        }
    }

    protected override void MovePlayer(Rigidbody2D rb2D, float moveSpeed, Vector2 clampedVel, float limitVel, bool isLanding)
    {
        base.MovePlayer(rb2D, moveSpeed, clampedVel, limitVel, isLanding);
        Anim.SetFloat("axisX", Mathf.Abs(Axis.x));
        if (IsLanding && Axis.x != 0f)
        {
            GameManager.instance.PlaySFXContinius(3, 0.2f);
        }
    }

    private new void Update()
    {
        if (!KnockingBack)
        {
            base.Update();
            MovePlayer(Rb2D, MoveSpeed, ClampedVel, LimitVel, IsLanding);
            Jump(Rb2D, JumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            GameManager.instance.PlaySFX(1, 0.5f);
            Destroy(collision.gameObject);
        }
    }

    public IEnumerator KnockBack(float delay, float force, Vector2 dir)
    {
        KnockingBack = true;
        Rb2D.AddForce(dir * force, ForceMode2D.Impulse);
        yield return new WaitForSeconds(delay);
        KnockingBack = false;
        
    }
}
