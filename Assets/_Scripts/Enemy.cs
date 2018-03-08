using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    IEnumerator patrol;
    IEnumerator moveRight;
    IEnumerator moveLeft;
    [SerializeField]
    float delay;
    [SerializeField]
    float speedPatrol;
    enum Direction{right, left }
    [SerializeField]
    Direction direction;

    Rigidbody2D rb2D;
    BoxCollider2D bc2D;

    public BoxCollider2D Bc2D
    {
        get
        {
            return bc2D;
        }
    }

    public Rigidbody2D Rb2D
    {
        get
        {
            return rb2D;
        }
    }

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        bc2D = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        patrol = Patrolling(delay);
        moveRight = Moving(Vector2.right,0);
        moveLeft = Moving(Vector2.left, 0);
        StartCoroutine(patrol);
    }

    IEnumerator Patrolling(float delay)
    {
        while (true)
        {
            if(direction == Direction.right)
            {
               StartCoroutine( moveRight);
            }
            if (direction == Direction.left)
            {
               StartCoroutine(moveLeft);
            }
            yield return new WaitForSeconds(delay);
            switch (direction)
            {
                case Direction.right:
                    StopCoroutine(moveRight);
                    direction = Direction.left;
                    break;
                case Direction.left:
                    StopCoroutine(moveLeft);
                    direction = Direction.right;
                    break;

            }
           
        }
    }

    IEnumerator Moving(Vector2 movDir ,float delay)
    {
        while (true)
        {
            transform.Translate(movDir * speedPatrol * Time.deltaTime);
            yield return new WaitForSeconds(delay);
        }
    }
}
