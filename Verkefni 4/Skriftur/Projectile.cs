using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Þetta script stýrir hegðun skotsins sem leikmaður skýtur
public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d; // Eðlisfræðieining sem sér um hreyfingu

    // Kallað þegar hluturinn er búinn til (t.d. þegar skotið er skotið)
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); // Nær í Rigidbody2D eininguna
    }

    // Kallað í hverri ramma
    void Update()
    {
        // Ef skotið hefur farið of langt (100 einingar frá miðju), eyða því
        if (transform.position.magnitude > 100.0f)
        {
            Destroy(gameObject);
        }
    }

    // Skýtur skotinu í tiltekna stefnu með ákveðnu afli
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force); // Beitir krafti í þá stefnu
    }

    // Þegar skotið rekst á eitthvað
    void OnTriggerEnter2D(Collider2D other)
    {
        // Ef það sem rekst á er óvinur, þá "lagar" það hann
        EnemyController enemy = other.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.Fix();
        }

        // Skotið eyðist eftir að hafa rekist á eitthvað
        Destroy(gameObject);
    }
}
