using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Takki : MonoBehaviour
{
    public TextMeshProUGUI texti; // Textinn sem birtist á skjánum (t.d. lokaskjár)

    public void Start()
    {
        // Ef virka sena er með buildIndex = 2, þá erum við í lokaborðinu og birta á niðurstöðu
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            texti.text = "Til hamingju, þú fékkst " + PlayerController.points.ToString() + " brauð!";
        }
    }

    // Fall sem er kallað á þegar notandi vill byrja leikinn
    public void Byrja()
    {
        Cursor.lockState = CursorLockMode.None; // Læsir ekki músarbendli
        Cursor.visible = true; // Gert músarbendil sýnilegan
        PlayerController.points = 0; // Núllstillir stig
        SceneManager.LoadScene(1); // Hleður borði 1 (leikurinn byrjar)
    }

    // Fall sem er kallað á þegar notandi vill fara í aðalvalmynd
    public void Endir()
    {
        Cursor.lockState = CursorLockMode.None; // Læsir ekki músarbendli
        Cursor.visible = true; // Sýnir músarbendil
        SceneManager.LoadScene(0); // Fer í aðalvalmynd (senan með buildIndex = 0)
    }
}
