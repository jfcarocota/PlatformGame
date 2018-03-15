using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtils;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]

public abstract class Character : PlayerBehaviours
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

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    JumpSystem jumpSystem;
    bool isLanding;

    bool knockingBack;

    bool isOnCinematic;

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

    private void FixedUpdate()
    {
    }

    protected void Update()
    {
        isLanding = jumpSystem.IsLanding(transform.position);
        FlipSprite();
    }

    void FlipSprite()
    {
        spr.flipX = Axis.x > 0f ? false : Axis.x < 0f ? true : spr.flipX;
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


    public bool IsLanding
    {
        get
        {
            return isLanding;
        }
    }

    public Vector2 ClampedVel
    {
        get
        {
            return clampedVel;
        }

        set
        {
            clampedVel = value;
        }
    }

    public float LimitVel
    {
        get
        {
            return limitVel;
        }

        set
        {
            limitVel = value;
        }
    }

    public float MoveSpeed
    {
        get
        {
            return moveSpeed;
        }

        set
        {
            moveSpeed = value;
        }
    }

    public bool IsLanding1
    {
        get
        {
            return isLanding;
        }

        set
        {
            isLanding = value;
        }
    }

    public float JumpForce
    {
        get
        {
            return jumpForce;
        }

        set
        {
            jumpForce = value;
        }
    }

    public bool KnockingBack
    {
        get
        {
            return knockingBack;
        }

        set
        {
            knockingBack = value;
        }
    }

    public bool IsOnCinematic
    {
        get
        {
            return isOnCinematic;
        }

        set
        {
            isOnCinematic = value;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = jumpSystem.RayColor;
        Gizmos.DrawRay(transform.position, Vector2.down * jumpSystem.RayDistance);
    }
}
