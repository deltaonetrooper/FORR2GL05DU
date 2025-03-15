using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f;//Hra�i b�lsins
    private float turnSpeed = 45.0f;//Sn�ningshra�i b�lsins
    private float horizontalInput;//L�r�tt inntak (vinstri/h�gri �rvar e�a A/D)
    private float verticalInput;//L��r�tt inntak (upp/ni�ur �rvar e�a W/S)

    //Start er kalla� einu sinni ��ur en Update er kalla� fyrst eftir a� MonoBehaviour er b�i� til
    void Start()
    {

    }

    //Update er kalla� � hvert skipti sem vi� uppf�rum leikinn
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");//Les l�r�tt inntak fr� leikmanni (vinstri/h�gri �rvar e�a A/D)
        verticalInput = Input.GetAxis("Vertical");//Les l��r�tt inntak fr� leikmanni (upp/ni�ur �rvar e�a W/S)

        //L�tur b�linn fara �fram samkv�mt l��r�tt inntak
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        //L�tur b�linn sn�ast samkv�mt l�r�tt inntak
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}

