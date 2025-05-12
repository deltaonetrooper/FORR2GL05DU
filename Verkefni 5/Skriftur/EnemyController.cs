using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Almennar breytur
    public float speed; // Hraði óvinarins
    public bool vertical; // Á óvinurinn að hreyfast upp/niður (true) eða til hliðar (false)
    public float changeTime = 3.0f; // Tími sem líður milli stefnu-skipta

    // Einkabreytingar
    Rigidbody2D rigidbody2d; // Tilvísun í Rigidbody2D fyrir hreyfingu
    Animator animator; // Tilvísun í Animator til að stjórna hreyfimyndum
    float timer; // Teljari fyrir hvenær á að skipta um stefnu
    int direction = 1; // Núverandi stefna (1 = áfram, -1 = afturábak)

    public RuntimeAnimatorController hitAnimatorController; // Hreyfing sem á að spila þegar óvinurinn verður sleginn

    bool isDefeated = false; // Til að koma í veg fyrir tvöfalt "hit"

    // Keyrt við ræsingu hlutar
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        timer = changeTime; // Upphafsstilling á teljara
    }

    void Update()
    {
        timer -= Time.deltaTime; // Lækkar tímann

        if (timer < 0)
        {
            direction = -direction; // Skiptir um stefnu
            timer = changeTime; // Endurstillir tímann
        }
    }

    // Fast physics uppfærsla – betra fyrir hreyfingu með rigidbody
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;

        if (vertical)
        {
            position.y += speed * direction * Time.deltaTime;
        }
        else
        {
            position.x += speed * direction * Time.deltaTime;
        }

        rigidbody2d.MovePosition(position); // Hreyfir óvininn
    }

    // Kallað þegar óvinurinn verður fyrir skoti eða árekstri
    public void OnHit()
    {
        if (isDefeated) return; // Passar að þetta gerist bara einu sinni

        isDefeated = true; // Setur óvin í "sigraðan" status

        if (hitAnimatorController != null)
        {
            animator.runtimeAnimatorController = hitAnimatorController; // Setur nýja hreyfimynd
        }

        Destroy(gameObject, 0.5f); // Eyðir óvin eftir 0.5 sekúndu (gefur tíma fyrir hreyfimynd)
    }

    // Ef óvinurinn rekst á leikmanninn
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.ChangeHealth(-1); // Lækkar heilsu leikmannsins um 1
        }
    }
}
