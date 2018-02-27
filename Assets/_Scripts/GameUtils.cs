using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUtils
{

    public abstract class PlayerBehaviours : MonoBehaviour
    {
        protected virtual void MovePlayer(Rigidbody2D rb2D, float moveSpeed, Vector2 clampedVel, float limitVel, bool isLanding)
        {
            rb2D.AddForce(Vector2.right * moveSpeed * Axis.normalized.x, ForceMode2D.Impulse);
            clampedVel = Vector2.ClampMagnitude(rb2D.velocity, limitVel);
            rb2D.velocity = new Vector2(clampedVel.x, rb2D.velocity.y);

            if (rb2D.velocity.x != 0f && isLanding)
            {
                rb2D.velocity = Axis.x != 0f ? rb2D.velocity : new Vector2(0f, rb2D.velocity.y);
            }
        }

        protected virtual void Jump(Rigidbody2D Rb2D, float jumpForce)
        {
            Rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        protected Vector2 Axis
        {
            get { return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); }
        }

        protected bool Btn_jump(bool isLanding)
        {
            return Input.GetButtonDown("Jump") && isLanding;
        }
    }
}
