using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Start acting
            GameManager.instance.PlayerIsActing = true;
            GameManager.instance.PlayerAnim.SetFloat("axisX", 0f);
            GameManager.instance.Pd.Play();
        }
    }
}
