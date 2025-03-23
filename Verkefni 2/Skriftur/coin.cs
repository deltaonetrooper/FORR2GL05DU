using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start er kallað einu sinni áður en fyrsta Update keyrir eftir að MonoBehaviour er búið til
    void Start()
    {

    }

    // Update er kallað einu sinni í hverjum ramma
    void Update()
    {

    }

    // Þetta fall eyðir hlutnum ef einhver rekst á hann
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
