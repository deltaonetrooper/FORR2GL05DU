using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public float speed = 2f; //hraði hreyfingar
    public float distance = 3f; //Fjarlægð sem hlutinn færist frá upphafsstöðu

    private Vector3 startPosition;
    private bool movingRight = true;

    void Start()
    {
        startPosition = transform.position; //vista upphafsstöðu
    }

    void Update()
    {
        if (movingRight)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0); //færist til hægri
            if (transform.position.x >= startPosition.x + distance)
            {
                movingRight = false; //breyta um stefnu
            }
        }
        else
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0); //færist til vinstri
            if (transform.position.x <= startPosition.x - distance)
            {
                movingRight = true; //breyta um stefnu
            }
        }
    }
}
