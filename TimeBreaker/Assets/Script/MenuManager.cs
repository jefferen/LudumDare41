using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI menuContent, headLine;
    public AudioSource select;
    List<string> menuText = new List<string>()
    { "You are a detective on a murder case, but the bigger problem is that the only way you can get people to talk, is with your BULLETS!",
    "Use WASD to move, and mouse to aim and shoot!", "Who will you shoot!", "Controls!"};

	void Start ()
    {
        Intro();
        select.enabled = true;
    }

    void Intro()
    {
        select.Play();
        menuContent.text = menuText[0];
        headLine.text = menuText[2];
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Help()
    {
        select.Play();
        headLine.text = menuText[3];
        menuContent.text = menuText[1];
    }

    public void Etc()
    {
        select.Play();
        Intro();
    }
}