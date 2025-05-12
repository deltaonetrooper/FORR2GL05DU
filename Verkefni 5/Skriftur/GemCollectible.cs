using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollectible : MonoBehaviour
{
    // Þetta fall keyrist þegar einhver snertir trigger-collider á þessum hlut
    void OnTriggerEnter2D(Collider2D other)
    {
        // Athugar hvort hluturinn sem snertir sé merktur sem "Player"
        if (other.CompareTag("Player"))
        {
            // Reynir að ná í PlayerController scriptu af leikmanninum
            PlayerController controller = other.GetComponent<PlayerController>();

            if (controller != null)
            {
                controller.ChangePoints(1); // Bætir við 1 stigi
            }

            Destroy(gameObject); // Eyðir gimsteinum af leiksvæðinu
        }
    }
}
