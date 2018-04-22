using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public GameObject stars, buildings, player;
    float currentPlayerPos;

	void Update ()
    {
		if(player.transform.position.x != currentPlayerPos)
        {
            stars.transform.position = new Vector2(player.transform.position.x * 0.99f - 1.5f, player.transform.position.y);
            buildings.transform.position = new Vector2(player.transform.position.x * 0.93f - 13, player.transform.position.y);
        }
	}
}
