using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHitTop : MonoBehaviour {

    [SerializeField]
    Enemy enemey;
    Collider2D col;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemey.Bc2D.enabled = false;
            GameManager.instance.PlaySFX(2, 1f);
            enemey.Rb2D.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
            col.enabled = false;
        }
    }
}
