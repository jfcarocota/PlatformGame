﻿using System.Collections;
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

            if (GameManager.instance.PlayerIsActing)
            {

                Debug.Log("Acting");
            }
        }
    }
}
