using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPlayerInFrame : MonoBehaviour
{
    public GameObject player;

    private void LateUpdate() // running out of time! this is way to simple
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1, -10);
    }
}
