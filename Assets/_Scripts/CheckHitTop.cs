using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHitTop : MonoBehaviour {

    [SerializeField]
    Enemy enemey;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemey.Bc2D.enabled = false;
        }
    }
}
