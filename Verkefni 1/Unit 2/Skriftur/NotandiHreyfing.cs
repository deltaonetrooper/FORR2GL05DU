using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 10f;

    public GameObject projectilePrefab;

    public float dashSpeed = 25f;   // Hraði við dashes
    public float dashTime = 0.2f;   // Lengd dash
    private bool isDashing = false;
    private float dashCooldown = 1f; // Tími áður en leikmaður getur notað dash aftur
    private float lastDashTime;

    void Update()
    {
        // Skýtur út verkefni þegar mellur á Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

        // Hindrar leikmanninn frá því að fara út úr mörkum
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Venjuleg hreyfing (slökkt á hreyfingu meðan á dash stendur)
        if (!isDashing)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        }

        // Dash fyrirmæli (stuðningur við vinstri og hægri shift)
        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            && Time.time > lastDashTime + dashCooldown)
        {
            if (Input.GetKey(KeyCode.A)) // Dash til vinstri
                StartCoroutine(Dash(-1));
            else if (Input.GetKey(KeyCode.D)) // Dash til hægri
                StartCoroutine(Dash(1));
        }
    }

    // Dash aðgerð
    System.Collections.IEnumerator Dash(int direction)
    {
        isDashing = true;
        float startTime = Time.time;

        // Hreyfing meðan á dash stendur
        while (Time.time < startTime + dashTime)
        {
            transform.Translate(Vector3.right * direction * dashSpeed * Time.deltaTime);
            yield return null;
        }

        isDashing = false;
        lastDashTime = Time.time;
    }
}
