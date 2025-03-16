using UnityEngine;

public class PizzaForward : MonoBehaviour
{
    public float speed = 40; // Hraði fyrir pizzuna

    // Start er kallað einu sinni áður en fyrsta keyrslu Update fer fram eftir að MonoBehaviour er búin til
    void Start()
    {
        
    }

    // Update er kallað einu sinni fyrir hverja mynd (frame)
    void Update()
    {
        // Hreyfir pizzuna áfram með þeim hraða sem tilgreindur er
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
