using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Takki : MonoBehaviour
{
    public TextMeshProUGUI texti; //texti sem birtist á skjánum

    public void Start()
    {

    }

    public void Byrja()
    {
        Cursor.lockState = CursorLockMode.None; //aflæsir mús
        Cursor.visible = true; //sýnir músina
        SceneManager.LoadScene(1); //fer í fyrsta borð
    }

    public void Endir()
    {
        Cursor.lockState = CursorLockMode.None; //aflæsir mús
        Cursor.visible = true; //sýnir músina
        SceneManager.LoadScene(0); //fer í aðalvalmynd
    }
}
