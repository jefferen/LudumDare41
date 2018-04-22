using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // what happens when this is being pressed in a webGL?
        {
            Application.Quit();
        }
	}
}
