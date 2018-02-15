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

    protected virtual void MovePlayer()
    {
        transform.Translate(Vector2.right * Axis.x * moveSpeed * Time.deltaTime);
    }

    /*protected abstract void MovePlayerAbstractVer();

    protected abstract void Jump();

    protected abstract void Attack();

    protected abstract void Die();*/


    Vector2 Axis
    {
        
        get { return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); }
    }
}
