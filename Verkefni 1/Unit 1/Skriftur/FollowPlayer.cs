using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;//Hlutinn sem fylgir leikmanninum
    private Vector3 offset = new Vector3(0, 5, -7);//Fjarlægðin milli fylgjandans og leikmannsins

    //Start er kallað einu sinni áður en Update er kallað fyrst eftir að MonoBehaviour er búið til
    void Start()
    {

    }

    //LateUpdate er kallað í hvert skipti eftir að Update er kallað, notað fyrir fylgni og myndavélarhreyfingar
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;//Setjum staðsetningu fylgjandans út frá leikmanninum og fjarlægðinni
    }
}
