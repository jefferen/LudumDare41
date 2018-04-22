using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accuse : MonoBehaviour
{
    public TMPro.TextMeshProUGUI Accusation;
    GameObject target;

	void Start ()
    {
        Accusation.text = "";
	}

	void Update ()
    {
        if (!target) return; // no target! try again later
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // just check if it has the killer script!
            Debug.Log(target);
            if (target.GetComponent<Murdere>())
            {
                Accusation.text = "You found the murdere";
                target.GetComponentInParent<Dialog>().DieAndSpeak();
            }
            else
                Accusation.text = "This person is not gulity of murder";
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        target = other.gameObject;
        Accusation.text = "Press 'Q' to accuse";
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        target = null;
        Accusation.text = "";
    }
}
