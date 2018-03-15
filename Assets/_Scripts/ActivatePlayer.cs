using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePlayer : MonoBehaviour {

    private void Start()
    {
        GameManager.instance.PlayerIsActing = false;
    }
}
