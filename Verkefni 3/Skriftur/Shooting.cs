using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet; //prefab fyrir kúlu
    public float speed = 4000f; //hraði kúlu

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("skjOtttttttta");

            GameObject instBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject; //býr til kúlu
            Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>(); //nær í rigidbody
            instBulletRigidbody.AddForce(transform.forward * speed); //skýtur kúlunni áfram
            Destroy(instBullet, 0.5f); //kúla eytt eftir 0.5sek
        }
    }
}
