using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    // Start er kallað einu sinni áður en fyrsta keyrslu Update fer fram eftir að MonoBehaviour er búin til
    void Start()
    {
        
    }

    // Update er kallað einu sinni fyrir hverja mynd (frame)
    void Update()
    {
        
    }

    // Kallað þegar viðkomandi collider kemst inn í trigger svæði
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject); // Eyðir eigin leikmanns- eða hlutarefni
        Destroy(other.gameObject); // Eyðir öðrum leikmanns- eða hlutarefni sem snertir
    }
}
