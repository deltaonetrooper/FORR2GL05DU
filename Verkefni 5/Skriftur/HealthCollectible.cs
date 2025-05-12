using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    // Þetta fall keyrir þegar einhver collider snertir trigger-collider á þessum hlut
    void OnTriggerEnter2D(Collider2D other)
    {
        // Reynir að ná í PlayerController scriptuna af hlutnum sem snertir
        PlayerController controller = other.GetComponent<PlayerController>();

        // Ef hluturinn er leikmaður og hefur minna en hámarks heilsu
        if (controller != null && controller.health < controller.maxHealth)
        {
            controller.ChangeHealth(1); // Bætir við 1 í heilsu
            Destroy(gameObject); // Eyðir heilsuhlutnum af leiksvæðinu
        }
    }
}
