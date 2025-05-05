using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Þetta script skilgreinir svæði sem veldur skaða þegar leikmaður er innan þess
public class DamageZone : MonoBehaviour
{
    // Þetta fall er kallað á hverri ramma á meðan eitthvað er inni í svæðinu (með "isTrigger" virkt)
    void OnTriggerStay2D(Collider2D other)
    {
        // Athugar hvort hluturinn sem er inni í trigger-svæðinu sé leikmaður
        PlayerController controller = other.GetComponent<PlayerController>();

        // Ef svo er, veldur hann 1 í skaða á hverri ramma
        if (controller != null)
        {
            controller.ChangeHealth(-1); // Drar úr heilsu leikmanns um 1
        }
    }
}
