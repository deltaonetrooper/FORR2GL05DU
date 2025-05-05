using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Þetta script er notað fyrir heilsu-hluti sem leikmaður getur tínt upp
public class HealthCollectible : MonoBehaviour
{
    // Þetta fall er kallað þegar annað collider rekst á þennan hlut (með "isTrigger" virkt)
    void OnTriggerEnter2D(Collider2D other)
    {
        // Reynir að nálgast PlayerController á hlutnum sem rekst á
        PlayerController controller = other.GetComponent<PlayerController>();

        // Ef það er leikmaður og hann er ekki með fulla heilsu
        if (controller != null && controller.health < controller.maxHealth)
        {
            controller.ChangeHealth(1); // Bætir við 1 heilsu
            Destroy(gameObject);       // Eyðir heilsu-hlutanum úr leiknum
        }
    }
}
