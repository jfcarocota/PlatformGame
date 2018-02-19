using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]

public abstract class Character : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb2D;
    [SerializeField]
    float limitVel;
    bool isStoped = true;
    Vector2 clampedVel;
    [SerializeField]
    float jumpForce;
    bool btn_jump;

    [SerializeField]
    float moveSpeed;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb2D.freezeRotation = true;
    }

    protected void Update()
    {
        btn_jump = Input.GetButtonDown("Jump");
    }

    protected virtual void MovePlayer()
    {
        rb2D.AddForce(Vector2.right * moveSpeed * Axis.normalized.x, ForceMode2D.Impulse);
        clampedVel = Vector2.ClampMagnitude(rb2D.velocity, limitVel);
        rb2D.velocity = new Vector2(clampedVel.x, rb2D.velocity.y);

        if (rb2D.velocity.x != 0f)
        {
            rb2D.velocity = Axis.x != 0f ? rb2D.velocity : new Vector2(0f, rb2D.velocity.y);
        }
    }

    protected virtual void Jump()
    {
        if (btn_jump)
        {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    Vector2 Axis
    {
        get { return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); }
    }
}
