using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public string dialog; // give random dialog!
    public TMPro.TextMeshProUGUI dialogBox;
    public AudioSource umph;

	public void DieAndSpeak() // type the text;
    {
        umph.Play();
        dialogBox.text = dialog;
    }
}
