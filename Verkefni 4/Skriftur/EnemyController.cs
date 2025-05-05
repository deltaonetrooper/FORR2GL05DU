using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Þetta script stýrir hreyfingu og hegðun óvinar (enemy) í leiknum
public class EnemyController : MonoBehaviour
{
    // Opinberar breytur sem hægt er að stilla í Unity inspector
    public float speed;                // Hraði óvinar
    public bool vertical;             // Hvort hann hreyfist lóðrétt eða lárétt
    public float changeTime = 3.0f;   // Tími milli þess sem hann snýr við

    // Einkabreytingar
    Rigidbody2D rigidbody2d;          // Tilvísun í Rigidbody2D fyrir eðlisfræði
    Animator animator;                // Tilvísun í Animator til að stýra hreyfingum
    float timer;                      // Niðurteljari til að breyta stefnu
    int direction = 1;                // Stefna hreyfingar (1 eða -1)
    bool broken = true;              // Segir til um hvort óvinurinn virki (sé brotinn eða „viðgerð“)

    // Kallað þegar leikurinn byrjar
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); // Sækir Rigidbody2D eininguna
        animator = GetComponent<Animator>();       // Sækir Animator eininguna
        timer = changeTime;                        // Upphafsstillir tímann
    }

    // Uppfært í hverri ramma
    void Update()
    {
        timer -= Time.deltaTime; // Telur niður

        // Ef tíminn er búinn, snýr við og endurstillir tímann
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    // FastUpdate fyrir physics-tengda hreyfingu
    void FixedUpdate()
    {
        if (!broken)
        {
            return; // Ef óvinurinn er "viðgerður", hreyfist hann ekki
        }

        Vector2 position = rigidbody2d.position;

        // Hreyfir óvininn lóðrétt eða lárétt eftir stillingu
        if (vertical)
        {
            position.y += speed * direction * Time.deltaTime;
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", direction);
        }
        else
        {
            position.x += speed * direction * Time.deltaTime;
            animator.SetFloat("MoveX", direction);
            animator.SetFloat("MoveY", 0);
        }

        // Hreyfir óvininn á nýja staðinn
        rigidbody2d.MovePosition(position);
    }

    // Þegar einhver hlutur fer inn í trigger svæði óvinarins
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        // Ef það er leikmaður sem snertir óvininn, veldur hann skaða
        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    // Eyðir óvininum þegar hann lendir í árekstri við einhvern annan hlut
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    // Kallað utan frá til að "laga" óvininn og slökkva á honum
    public void Fix()
    {
        broken = false;                              // Óvinurinn hættir að virka
        GetComponent<Rigidbody2D>().simulated = false; // Slökkva á physics simulation
        animator.SetTrigger("Fixed");                // Spilar "viðgerð" animation
    }
}
