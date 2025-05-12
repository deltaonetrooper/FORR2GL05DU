using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d; // Tilvísun í Rigidbody2D fyrir hreyfingu kúlu

    // Awake er kallað þegar hluturinn er fyrst virkur í senunni
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); // Nær í Rigidbody2D komponentinn
    }

    void Start()
    {
        Destroy(gameObject, 5f); // Eyðir skotinu sjálfkrafa eftir 5 sekúndur
    }

    void Update()
    {
        // Notað ef við viljum bæta við einhverri virkni á hverjum ramma
    }

    // Skýtur skotinu í ákveðna átt með ákveðnu afli
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force); // Beitir krafti í gefna átt
    }

    // Þegar kúlan rekst á einhvern hlut
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Projectile collision with " + other.gameObject); // Prentar í console hvað skotið snerti

        EnemyController enemy = other.GetComponent<EnemyController>(); // Athugar hvort hluturinn sé óvinur

        if (enemy != null)
        {
            enemy.OnHit(); // Kallar á OnHit fall óvinarins ef hann er til staðar
        }

        Destroy(gameObject); // Eyðir skotinu eftir árekstur
    }
}
