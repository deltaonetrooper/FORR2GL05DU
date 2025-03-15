using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;//Hlutinn sem fylgir leikmanninum
    private Vector3 offset = new Vector3(0, 5, -7);//Fjarl�g�in milli fylgjandans og leikmannsins

    //Start er kalla� einu sinni ��ur en Update er kalla� fyrst eftir a� MonoBehaviour er b�i� til
    void Start()
    {

    }

    //LateUpdate er kalla� � hvert skipti eftir a� Update er kalla�, nota� fyrir fylgni og myndav�larhreyfingar
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;//Setjum sta�setningu fylgjandans �t fr� leikmanninum og fjarl�g�inni
    }
}
