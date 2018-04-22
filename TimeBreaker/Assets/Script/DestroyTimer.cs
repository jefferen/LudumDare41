using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        Invoke("Destroy", 0.85f);
	}
	
    void Destroy()
    {
        Destroy(gameObject);
    }
}
