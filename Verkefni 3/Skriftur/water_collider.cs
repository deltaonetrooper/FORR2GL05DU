using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class water_collider : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Endurræsa(); //endurræsir leik þegar leikmaður lendir í vatni
        }
    }

    public void Endurræsa()
    {
        SceneManager.LoadScene(0); //fer í aðalvalmynd
        Cursor.lockState = CursorLockMode.None; //aflæsir mús
        Cursor.visible = true; //sýnir músina
    }
}
