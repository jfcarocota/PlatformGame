using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]

public abstract class Character : MonoBehaviour
{
    SpriteRenderer spr;
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

    [SerializeField]
    JumpSystem jumpSystem;
    bool isLanding;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        rb2D.freezeRotation = true;
    }

    protected void Update()
    {
        isLanding = jumpSystem.IsLanding(transform.position);
        btn_jump = Input.GetButtonDown("Jump") && isLanding;
        FlipSprite();
    }

    void FlipSprite()
    {
        spr.flipX = Axis.x > 0f ? false : Axis.x < 0f ? true : spr.flipX;
    }

    protected virtual void MovePlayer()
    {
        Rb2D.AddForce(Vector2.right * moveSpeed * Axis.normalized.x, ForceMode2D.Impulse);
        clampedVel = Vector2.ClampMagnitude(Rb2D.velocity, limitVel);
        Rb2D.velocity = new Vector2(clampedVel.x, Rb2D.velocity.y);

        if (Rb2D.velocity.x != 0f && isLanding)
        {
            Rb2D.velocity = Axis.x != 0f ? Rb2D.velocity : new Vector2(0f, Rb2D.velocity.y);
        }
    }

    protected virtual void Jump()
    {
        Rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); 
    }

    protected Vector2 Axis
    {
        get { return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); }
    }

    public Animator Anim
    {
        get
        {
            return anim;
        }
    }

    public Rigidbody2D Rb2D
    {
        get
        {
            return rb2D;
        }
    }

    public bool Btn_jump
    {
        get
        {
            return btn_jump;
        }
    }

    public bool IsLanding
    {
        get
        {
            return isLanding;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = jumpSystem.RayColor;
        Gizmos.DrawRay(transform.position, Vector2.down * jumpSystem.RayDistance);
    }
}
