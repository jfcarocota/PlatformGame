using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    List<Transform> hearts;

    private void Start()
    {
        foreach(Transform t in transform)
        {
            hearts.Add(t);
        }
    }

    public void LostHearts()
    {
        if (hearts.Count <= 0) return;

        Destroy(hearts[hearts.Count -1].gameObject);
        hearts.RemoveAt(hearts.Count - 1);
    }
}
