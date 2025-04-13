using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    public static float stig = 0; //stig sem safnast upp
    private GameObject[] smallWalls; //veggir með tagið "small"
    private GameObject[] largeWalls; //veggir með tagið "big"

    void Start()
    {
        smallWalls = GameObject.FindGameObjectsWithTag("small"); //nær í litlu veggina
        largeWalls = GameObject.FindGameObjectsWithTag("big"); //nær í stóru veggina
    }

    void Update()
    {
        if (stig == 5)
        {
            foreach (GameObject wall in smallWalls)
            {
                Destroy(wall); //eyðir litlu veggjunum
            }
            Debug.Log("Hurð opin");
        }

        if (stig == 10)
        {
            foreach (GameObject walls in largeWalls)
            {
                Destroy(walls); //eyðir stóru veggjunum
            }
            Debug.Log("Stærri hurð opin");
        }
        if (stig == 20)
        {
            SceneManager.LoadScene(2); //fer í næstu senu
            Cursor.lockState = CursorLockMode.None; //opnar músina
            Cursor.visible = true; //gerir músina sýnilega
        }
    }
}
