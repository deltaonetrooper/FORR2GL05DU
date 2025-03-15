using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f;//Hraði bílsins
    private float turnSpeed = 45.0f;//Snúningshraði bílsins
    private float horizontalInput;//Lárétt inntak (vinstri/hægri örvar eða A/D)
    private float verticalInput;//Lóðrétt inntak (upp/niður örvar eða W/S)

    //Start er kallað einu sinni áður en Update er kallað fyrst eftir að MonoBehaviour er búið til
    void Start()
    {

    }

    //Update er kallað í hvert skipti sem við uppfærum leikinn
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");//Les lárétt inntak frá leikmanni (vinstri/hægri örvar eða A/D)
        verticalInput = Input.GetAxis("Vertical");//Les lóðrétt inntak frá leikmanni (upp/niður örvar eða W/S)

        //Lætur bílinn fara áfram samkvæmt lóðrétt inntak
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        //Lætur bílinn snúast samkvæmt lárétt inntak
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}

