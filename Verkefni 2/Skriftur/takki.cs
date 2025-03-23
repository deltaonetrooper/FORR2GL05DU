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
        // Ef leikmaður er í borði númer 4, sýnir lokastig
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            texti.text = "Lokastig " + PlayerMovment.count.ToString();
        }
    }

    // Byrjar leikinn frá fyrsta borði og núllstillir stig ef ýtt er á takkann
    public void Byrja()
    {
        SceneManager.LoadScene(1);
        PlayerMovment.count = 0;
    }

    // Fer aftur í aðalvalmynd og núllstillir stig
    public void Endir()
    {
        SceneManager.LoadScene(0);
        PlayerMovment.count = 0;
    }
}
