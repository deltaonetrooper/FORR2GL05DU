using UnityEngine;

public class DestroyTopBound : MonoBehaviour
{
    private float topBound = 30;//Ef hlutinn fer yfir þessa línu, verður hann eytt
    private float lowerBound = -10;//Ef hlutinn fer neðan þessa línu, verður hann eytt

    private float teljari = 0;//Breyta fyrir talningu (ekki notað í þessari útgáfu)
    
    //Start er kallað einu sinni áður en Update er kallað fyrst eftir að MonoBehaviour er búið til
    void Start()
    {
        
    }

    //Update er kallað í hvert skipti sem við uppfærum leikinn
    void Update()
    {
        //Ef staðsetningin á hlutnum fer yfir topp mörkin (topBound), eyttum við honum
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        } 
        //Ef staðsetningin á hlutnum fer undir neðri mörkin (lowerBound), eyttum við honum og prentum "Game Over!"
        else if (transform.position.z < lowerBound) 
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
