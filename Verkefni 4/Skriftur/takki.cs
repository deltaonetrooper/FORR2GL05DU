using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Takki : MonoBehaviour
{
    // Breyta fyrir texta á skjánum
    public TextMeshProUGUI texti;

    public void Start()
    {

    }

    // Byrjar leikinn frá fyrsta borði og núllstillir stig ef ýtt er á takkann
    public void Byrja()
    {
        SceneManager.LoadScene(1);
     
    }

    // Fer aftur í aðalvalmynd og núllstillir stig
    public void Endir()
    {
        SceneManager.LoadScene(0);
 
    }
}
