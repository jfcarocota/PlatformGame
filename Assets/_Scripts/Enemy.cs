using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    IEnumerator patrol;

    private void Start()
    {
        patrol = Patrolling();
        StartCoroutine(patrol);
    }

    IEnumerator Patrolling()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            Debug.Log("Hello after 5 seconds");
        }
    }
}
