using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Myndavel : MonoBehaviour
{
    // Tilvísun í leikmanninn sem myndavélin fylgir
    public Transform player;

    // Staðsetningarmunur milli myndavélar og leikmanns
    public Vector3 offset;

    // Rými þar sem offset er reiknað (Self eða World)
    private Space offsetPositionSpace = Space.Self;

    // Hvort myndavélin eigi að horfa á leikmanninn
    private bool lookAt = true;

    // Uppfært einu sinni í hverjum ramma
    void Update()
    {
        // Stillir staðsetningu myndavélarinnar miðað við offset
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = player.TransformPoint(offset);
        }
        else
        {
            transform.position = player.position + offset;
        }

        // Reiknar snúning myndavélarinnar
        if (lookAt)
        {
            transform.LookAt(player); // Myndavélin horfir á leikmanninn
        }
        else
        {
            transform.rotation = player.rotation; // Myndavélin fær sama snúning og leikmaðurinn
        }
    }
}
